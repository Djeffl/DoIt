using DoIt.Client.Models.General;

using Microsoft.AspNetCore.Components;

using DoIt.Client.Services.Modals;
using System;

namespace DoIt.Client.Components.Modals
{
    public class BaseModalComponent<ParameterT> : BaseModalComponent
    {
        [Parameter]
        public ParameterT Parameter { get; set; }
    }

    public class BaseModalComponent : BaseComponent
    {
        [Inject]
        private ModalService _modalService { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        public void CloseModal()
        {
            _modalService.Close(Id);
        }

        public void CloseModal(ActionType actionType, object response)
        {
            _modalService.Close(actionType, response, Id);
        }
    }
}
