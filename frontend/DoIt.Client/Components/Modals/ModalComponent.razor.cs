using DoIt.Client.Models.Menus;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace DoIt.Client.Components.Modals
{
    public partial class ModalComponent : BaseComponent
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public Action CloseModal { get; set; }

        [Parameter]
        public IEnumerable<MenuOption> Options { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }
    }
}
