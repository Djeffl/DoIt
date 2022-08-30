﻿using DoIt.Client.Components;
using DoIt.Client.Models.General;
using DoIt.Client.Pages.Ideas.Detail;
using DoIt.Interface.Ideas;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Client.Pages.Ideas
{
    public partial class IdeaOverviewPage : BaseComponent
    {
        public List<IdeaDto> Ideas { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Modal.OnClose += OnModalClose;
        }

        protected override async Task LoadDataAsync()
        {
            var getIdeasResponse = await IdeaService.GetAllAsync();
            Ideas = getIdeasResponse.Data.ToList();
            StateHasChanged();

        }

        private void OnModalClose(ActionType actionType, object response)
        {
            switch (actionType)
            {
                case ActionType.Create:
                    AddNewIdea(response as IdeaDto);
                    break;
                case ActionType.Update:
                    UpdateExistingIdea(response as IdeaDto);
                    break;
                case ActionType.Delete:
                    DeleteIdea(response as IdeaDto);
                    break;
            }
        }

        private void OpenDetailGoal(long id)
        {
            Modal.Show<IdeaDetailPage, IdeaDetailParameter>(new IdeaDetailParameter() { IdeaId = id });
        }

        private async void AddNewIdea(IdeaDto _)
        {
            await LoadDataAsync();
        }

        private async void UpdateExistingIdea(IdeaDto _)
        {
            await LoadDataAsync();
        }

        private async void DeleteIdea(IdeaDto _)
        {
            await LoadDataAsync();
        }
    }
}
