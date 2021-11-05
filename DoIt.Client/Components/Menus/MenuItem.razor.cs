using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DoIt.Client.Components.Menus
{
	public partial class MenuItem : ComponentBase
	{
		[Parameter]
		public string Title { get; set; }

		[Parameter]
		public EventCallback<MouseEventArgs> OnClick { get; set; }
	}
}
