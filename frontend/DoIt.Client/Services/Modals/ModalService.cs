using System;

using DoIt.Client.Models.General;
using DoIt.Client.Models.Modals;

namespace DoIt.Client.Services.Modals
{
    public class ModalService
    {
        public event Action<Modal> OnShow;
        public event Action<ActionType, object, Guid> OnClose;

        public ModalService()
        {
        }

        public void Show(Modal modal)
        {
            OnShow?.Invoke(modal);
        }

        public void Close(Guid id)
        {
            OnClose?.Invoke(ActionType.Cancel, null, id);
        }

        public void Close(ActionType actionType, object response, Guid id)
        {
            OnClose?.Invoke(actionType, response, id);
        }
    }
}
