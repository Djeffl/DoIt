using DoIt.Client.Components.Modals;
using Microsoft.AspNetCore.Components;
using System;

namespace DoIt.Client.Models.Modals
{
    public class ModalBuilder
    {
        private RenderFragment _fragment;
        private object _parameter;
        private Type _modalComponentType;
        private ModalConfiguration _configuration;
        private Guid _id;

        public ModalBuilder AddComponent<TModalComponent>()
            where TModalComponent : BaseModalComponent
        {
            if (_fragment is not null)
            {
                throw new InvalidOperationException("Component already configured.");
            }

            _id = Guid.NewGuid();

            _fragment = new RenderFragment(x =>
            {
                x.OpenComponent(1, typeof(TModalComponent));
                x.AddAttribute(4, "Id", _id);
                x.CloseComponent();
            });

            _modalComponentType = typeof(TModalComponent);

            return this;
        }

        public ModalBuilder AddComponent<TModalComponent, TParameter>(TParameter parameter) 
            where TModalComponent : BaseModalComponent
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            if(_fragment is not null)
            {
                throw new InvalidOperationException("Component already configured.");
            }

            _id = Guid.NewGuid();

            _fragment = new RenderFragment(x =>
            {
                x.OpenComponent(1, typeof(TModalComponent));
                x.AddAttribute(3, "Parameter", parameter);
                x.AddAttribute(4, "Id", _id);
                x.CloseComponent();
            });

            _parameter = parameter;
            _modalComponentType = typeof(TModalComponent);

            return this;
        }

        public ModalBuilder AddConfiguration(ModalConfiguration configuration)
        {
            if(configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            _configuration = configuration;

            return this;
        }

        public Modal Build()
        {
            return new Modal()
            {
                Id = _id,
                Fragment = _fragment,
                Parameter = _parameter,
                ModalType = _modalComponentType,
                Configuration = _configuration
            };
        }
    }
}
