﻿using DoIt.Client.Components.Modals;
using DoIt.Client.Components.Modals.Confirm;
using DoIt.Client.Models.General;
using DoIt.Client.Models.Goals;
using DoIt.Client.Models.Ideas;
using DoIt.Client.Models.Menus;
using DoIt.Client.Models.Modals;
using DoIt.Client.Pages.Goals.Create;
using DoIt.Client.Services.Goals;
using DoIt.Interface.IdeaCategory;
using DoIt.Interface.Ideas;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Client.Pages.Ideas.Detail
{
    public partial class IdeaDetailPage : BaseModalComponent<IdeaDetailParameter>, IDisposable
    {
        public IdeaFormDto Idea { get; set; } = new IdeaFormDto();
        public IEnumerable<CategoryDto> IdeaCategories { get; set; } = new List<CategoryDto>();
        private EditContext EditContext;

        public List<MenuOption> Options { get; set; } = new List<MenuOption>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            ModalService.OnClose += OnModalClose;
        }

        public IdeaDetailPage()
        {
            Options.AddRange(new List<MenuOption>()
            {
                new MenuOption()
                {
                    Title = "Delete",
                    Icon = Models.Icons.IconType.Delete,
                    OnClick = () => this.StartDeleteIdea()
                },
                new MenuOption()
                {
                    Title = "Save",
                    OnClick= async () => await UpdateIdeaAsync(),
                    DefaultActive = true
                }
            });
        }

        private void OnModalClose(ActionType actionType, object response, Guid id)
        {

            if (actionType == ActionType.Confirm)
            {
                var confirmDelete = (bool)response;

                if (confirmDelete)
                {
                    DeleteIdea();
                }
            }

            if (actionType == ActionType.Create)
            {
                var newGoal = (GoalFormDto)response;

                UpgradeIdea(newGoal);
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
        }

        protected override async Task LoadDataAsync()
        {
            await base.LoadDataAsync();

            IdeaCategories = await GetIdeaCategoriesAsync();

            if (Parameter != null)
            {
                var idea = await IdeaService.GetAsync(Parameter.IdeaId);
                Idea = new IdeaFormDto
                {
                    Id = idea.Id,
                    Title = idea.Title,
                    Description = idea.Description,
                    CategoryNames = idea.Categories.Select(x => x.Name).ToList(),
                    GoalId = idea.GoalId,
                };

                if (Idea.GoalId == null)
                {
                    Options.Add(
                        new MenuOption()
                        {
                            Title = "As Goal",
                            Icon = Models.Icons.IconType.Goal,
                            OnClick = () => this.StartUpgradeIdea()
                        }
                    );
                }

                StateHasChanged();
            }
        }

        private async Task<IEnumerable<CategoryDto>> GetIdeaCategoriesAsync()
        {
            var categoriesDto = await IdeaCategoryService.GetListAsync();
            return categoriesDto.Data;
        }

        private async Task UpdateIdeaAsync()
        {
            await SetIdeaCategoryIdsAsync();

            await IdeaService.UpdateIdeaAsync(Idea.Id.Value,
                new UpdateIdeaDto()
                {
                    Title = Idea.Title,
                    Description = Idea.Description,
                    CategoryIds = Idea.CategoryIds,
                });

            CloseModal(ActionType.Update, Idea);
        }

        private async void UpgradeIdea(GoalFormDto goal)
        {
            var response = await GoalService.CreateGoalAsync(goal.ToService());
            CloseModal(ActionType.Create, response);

            NavigationManager.NavigateTo("/goals");
        }

        private void ToGoal()
        {
            NavigationManager.NavigateTo($"/goals/{Idea.GoalId.Value}");
            CloseModal(ActionType.None, null);
        }

        private void StartUpgradeIdea()
        {
            ModalService.Show(new ModalBuilder()
            .AddComponent<GoalCreatePage, GoalCreateParameter>(new GoalCreateParameter()
            {
                IdeaId = Idea.Id.Value,
            })
            .AddConfiguration(new ModalConfiguration() { FullScreen = true })
            .Build());
        }

        private void StartDeleteIdea()
        {
            ModalService.Show(new ModalBuilder()
            .AddComponent<ConfirmModalComponent, ConfirmModalParameter>(new ConfirmModalParameter() { Description = "Are you sure you wish to delete this idea?" })
            .AddConfiguration(new ModalConfiguration() { FullScreen = false })
            .Build());
        }

        private async void DeleteIdea()
        {
            await IdeaService.DeleteAsync(Idea.Id.Value);

            CloseModal(ActionType.Delete, Idea);
        }

        private async Task SetIdeaCategoryIdsAsync()
        {
            var categories = new List<CategoryDto>();

            if (!Idea.CategoryNames.Any())
            {
                Idea.CategoryIds = new List<long>();
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

        public void Dispose()
        {
            ModalService.OnClose -= OnModalClose;
        }
    }
}
