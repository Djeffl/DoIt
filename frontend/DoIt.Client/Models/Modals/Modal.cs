using DoIt.Client.Components.Modals;
using Microsoft.AspNetCore.Components;
using System;

namespace DoIt.Client.Models.Modals
{
    public class Modal<TModalComponent, TParameter> where TModalComponent : BaseModalComponent
    {
        public TModalComponent Component { get; set; }

        public ModalConfiguration Configuration { get; set; }

        public TParameter Parameter { get; set; }
    }

    public class Modal : Modal<BaseModalComponent, object>
    {
        public Type ModalType { get; internal set; }
        public RenderFragment Fragment { get; internal set; }
        public Guid Id { get; internal set; }
    }
}
