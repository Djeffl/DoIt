using DoIt.Client.Components.Modals;
using DoIt.Client.Models.General;
using DoIt.Client.Services.Ideas;
using DoIt.Interface.IdeaCategory;
using DoIt.Interface.Ideas;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Client.Pages.Ideas
{
    public partial class IdeaCreatePage : BaseModalComponent
    {
        public IEnumerable<CategoryDto> IdeaCategories { get; set; } = new List<CategoryDto>();
        public Models.Ideas.CreateIdeaDto NewIdea = new Models.Ideas.CreateIdeaDto();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected override async Task LoadDataAsync()
        {
            await base.LoadDataAsync();
            IdeaCategories = await GetIdeaCategoriesAsync();
        }

        private async Task CreateIdeaAsync()
        {
            await SetIdeaCategoryIdsAsync();

            var response = await IdeaService.CreateAsync(NewIdea.ToService());

            LogSuccess("Idea successfully created.");

            CloseModal(ActionType.Create, response);
        }

        private async Task<IEnumerable<CategoryDto>> GetIdeaCategoriesAsync()
        {
            var categoriesDto = await IdeaCategoryService.GetListAsync();
            return categoriesDto.Data;
        }

        private async Task SetIdeaCategoryIdsAsync()
        {
            var categories = new List<CategoryDto>();

            if (!NewIdea.CategoryNames.Any())
            {
                NewIdea.CategoryIds = new List<long>();
                return;
            }

            // GetAllNewCategories
            var newCategories = NewIdea.CategoryNames.Where(categoryName => !IdeaCategories.Any(existingCategory => categoryName == existingCategory.Name));

            if (newCategories.Any())
            {
                // Create new categories and add to list
                var bulkNewCategories = await AddNewIdeaCategoryBulkAsync(newCategories);
                categories.AddRange(bulkNewCategories.Data);
            }

            // Add all existing categories to the list
            categories.AddRange(IdeaCategories.Where(existingCategory => NewIdea.CategoryNames.Any(name => name == existingCategory.Name)));
            NewIdea.CategoryIds = categories.Select(selectedCategory => selectedCategory.Id);

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
    }
}
