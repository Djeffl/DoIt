using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Modal_Demo.Components
{
	public class ModalService
	{
		public Action<string, RenderFragment> OnShow;
		public Action OnClose;

		public object Response { get; set; }

		public ModalService()
		{

		}

		public void Show<T>(string title) where T : IComponent
		{
			Show(title, typeof(T));
		}

		public void Show(string title, Type contentType)
		{
			if (contentType.BaseType != typeof(ComponentBase))
			{
				throw new ArgumentException($"{contentType.FullName} must be a Blazor Component");
			}

			var modelContent = new RenderFragment(builder =>
			{
				builder.OpenComponent(1, contentType);
				//builder.AddAttribute(2, "TestNameParam", "Hello");
				//foreach (var parameter in parameters._parameters)
				//{
				//	builder.AddAttribute(i++, parameter.Key, parameter.Value);
				//}

				builder.CloseComponent();
			});



			OnShow?.Invoke(title, modelContent);
		}

		public void Close()
		{
			OnClose?.Invoke();
		}
	}
}
