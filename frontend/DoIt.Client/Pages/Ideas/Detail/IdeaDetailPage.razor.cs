using DoIt.Client.Components;
using DoIt.Client.Components.Modals;
using DoIt.Client.Models.General;
using DoIt.Client.Models.Loading;
using DoIt.Interface.Goals;
using DoIt.Interface.IdeaCategory;
using DoIt.Interface.Ideas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Client.Pages.Ideas.Detail
{
    public partial class IdeaDetailPage : BaseModalComponent<IdeaDetailParameter>
    {
        public IdeaDtoIdeaDetailPage Idea { get; set; } = new IdeaDtoIdeaDetailPage();
        public CreateGoalRequest UpgradedIdeaAsGoal { get; set; } = new CreateGoalRequest();
        public IEnumerable<CategoryDto> IdeaCategories { get; set; } = new List<CategoryDto>();
        private SectionType ActiveSection;

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            ActiveSection = SectionType.IdeaDetail;
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            var idea = await IdeaService.GetAsync(Parameter.IdeaId);
            Idea = new IdeaDtoIdeaDetailPage
            {
                Id = idea.Id,
                Title = idea.Title,
                Description = idea.Description,
                CategoryNames = idea.Categories.Select(x => x.Name).ToList(),
            };

            StateHasChanged();
        }

        protected override async Task LoadDataAsync()
        {
            await base.LoadDataAsync();

            IdeaCategories = await GetIdeaCategoriesAsync();
        }

        private async Task<IEnumerable<CategoryDto>> GetIdeaCategoriesAsync()
        {
            var categoriesDto = await IdeaCategoryService.GetListAsync();
            return categoriesDto.Data;
        }

        private async Task UpdateIdeaAsync()
        {
            await SetIdeaCategoryIdsAsync();

            await IdeaService.UpdateIdeaAsync(Idea.Id,
                new UpdateIdeaDto()
                {
                    Title = Idea.Title,
                    Description = Idea.Description,
                    CategoryIds = Idea.CategoryIds,
                });

            CloseModal(ActionType.Update, Idea);
        }

        private async void UpgradeIdea()
        {
            var response = await GoalService.CreateGoalAsync(UpgradedIdeaAsGoal);

            NavigationManager.NavigateTo("/goals");
        }

        private void StartUpgradeIdea()
        {
            ActiveSection = SectionType.UpgradeIdea;
            UpgradedIdeaAsGoal.Description = Idea.Description;
            UpgradedIdeaAsGoal.Title = Idea.Title;
        }

        private void StartDeleteIdea()
        {
            GoConfirmScreen();
        }

        private void GoConfirmScreen()
        {
            ActiveSection = SectionType.ConfirmDelete;
        }

        private void GoIdeaDetailScreen()
        {
            ActiveSection = SectionType.IdeaDetail;
        }

        private async void DeleteIdea()
        {
            await IdeaService.DeleteAsync(Idea.Id);

            Modal.Close(ActionType.Delete, Idea);
        }

        private string GetActive(SectionType sectionType)
        {
            return ActiveSection == sectionType ? "active" : "";
        }

        private async Task SetIdeaCategoryIdsAsync()
        {
            var categories = new List<CategoryDto>();

            if (!Idea.CategoryNames.Any())
            {
                return;
            }

            var newCategories = Idea.CategoryNames.Where(categoryName => !IdeaCategories.Any(existingCategory => categoryName == existingCategory.Name));

            if (newCategories.Any())
            {
                var bulkNewCategories = await AddNewIdeaCategoryBulkAsync(newCategories);
                categories.AddRange(bulkNewCategories.Data);
            }

            categories.AddRange(IdeaCategories.Where(existingCategory => Idea.CategoryNames.Any(name => name == existingCategory.Name)));
            Idea.CategoryIds = categories.Select(selectedCategory => selectedCategory.Id);

            await LoadDataAsync();
        }

        private async Task<CategoriesDto> AddNewIdeaCategoryBulkAsync(IEnumerable<string> categoryNames)
        {
            return await IdeaCategoryService.CreateBulkAsync(new CreateCategoryBulkDto
            {
                Categories = categoryNames.Select(name => new CreateCategoryDto()
                {
                    Name = name
                })
            });
        }

        private enum SectionType
        {
            IdeaDetail,
            ConfirmDelete,
            UpgradeIdea
        }

        private class ActionFlow
        {
            public string Name { get; set; }
            public Action Action { get; set; }
            public List<ActionFlow> FlowOptions { get; set; }
        }
    }
}
