using DoIt.Client.Components;
using DoIt.Client.Models.General;
using DoIt.Client.Models.Modals;
using DoIt.Client.Pages.Ideas.Detail;
using DoIt.Client.Services.Modals;
using DoIt.Interface.Ideas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Client.Pages.Ideas
{
    public partial class IdeaOverviewPage : BaseComponent, IDisposable
    {
        public List<IdeaDto> Ideas { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            ModalService.OnClose += OnModalClose;
        }

        protected override async Task LoadDataAsync()
        {
            var getIdeasResponse = await IdeaService.GetAllAsync();
            Ideas = getIdeasResponse.Data.ToList();
            StateHasChanged();

        }

        private void OnModalClose(ActionType actionType, object response, Guid id)
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
            ModalService.Show(new ModalBuilder()
                .AddComponent<IdeaDetailPage, IdeaDetailParameter>(new IdeaDetailParameter() { IdeaId = id })
                .AddConfiguration(new ModalConfiguration() { FullScreen = true })
                .Build());
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

        public void Dispose()
        {
            ModalService.OnClose -= OnModalClose;
        }
    }
}
