using DoIt.Client.Components;
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

        protected override async Task LoadAsync()
        {
            var getIdeasResponse = await IdeaService.GetAllAsync();
            Ideas = getIdeasResponse.Data.ToList();
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
            Modal.Show<IdeaDetailPage, IdeaDetailParameter>("Idea Details", new IdeaDetailParameter() { IdeaId = id });
        }

        private void AddNewIdea(IdeaDto idea)
        {
            Ideas.Add(idea);
            StateHasChanged();
        }

        private void UpdateExistingIdea(IdeaDto updatedIdea)
        {
            var idea = Ideas.FirstOrDefault(x => x.Id == updatedIdea.Id);
            if (idea is not null)
            {
                idea.Title = updatedIdea.Title;
                idea.Description = updatedIdea.Description;
            }
            StateHasChanged();
        }

        private void DeleteIdea(IdeaDto idea)
        {
            var ideaToDelete = Ideas.FirstOrDefault(x => x.Id == idea.Id);

            if (ideaToDelete is not null)
            {
                Ideas.Remove(ideaToDelete);
            }
            StateHasChanged();
        }
    }
}
