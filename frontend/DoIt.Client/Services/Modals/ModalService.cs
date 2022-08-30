using DoIt.Client.Components.Modals;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

using DoIt.Client.Models.General;

namespace DoIt.Client.Services.Modals
{
    public class ModalService
    {
        public event Action<RenderFragment> OnShow;
        public event Action<ActionType, object> OnClose;

        public ModalService()
        {
        }

        public void Show<ComponentT>()
        {
            var content = new RenderFragment(x =>
            {
                x.OpenComponent(1, typeof(ComponentT));
                x.CloseComponent();
            });
            OnShow?.Invoke(content);
        }

        //public void Show<ComponentT>(string title)
        //{
        //    var content = new RenderFragment(x =>
        //    {
        //        x.OpenComponent(1, typeof(ComponentT));
        //        x.CloseComponent();
        //    });
        //    OnShow?.Invoke(content, title);
        //}

        public void Show<ComponentT, ParameterT>(ParameterT parameter)
        {
            var content = new RenderFragment(x =>
            {
                x.OpenComponent(1, typeof(ComponentT));
                x.AddAttribute(3, "Parameter", parameter);
                x.CloseComponent();
            });
            OnShow?.Invoke(content);
        }

        //public void Show<ComponentT, ParameterT>(string title, ParameterT parameter)
        //{
        //    var content = new RenderFragment(x =>
        //    {
        //        x.OpenComponent(1, typeof(ComponentT));
        //        x.AddAttribute(3, "Parameter", parameter);
        //        x.CloseComponent();
        //    });
        //    OnShow?.Invoke(content, title);
        //}

        //public ResultT Show<ComponentT, ParameterT, ResultT>(ParameterT parameter) where ResultT : new()
        //{
        //    var content = new RenderFragment(x =>
        //    {
        //        x.OpenComponent(1, typeof(ComponentT));
        //        x.AddAttribute(2, "Parameter", parameter);
        //        x.CloseComponent();
        //    });

        //    var obj = new ResultT();

        //    OnShow?.Invoke(content, "");

        //    return obj;
        //}

        public void Close()
        {
            OnClose?.Invoke(ActionType.Cancel, null);
        }

        public void Close(ActionType actionType, object response)
        {
            OnClose?.Invoke(actionType, response);
        }
    }
}
