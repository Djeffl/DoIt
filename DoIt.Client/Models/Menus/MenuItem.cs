using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DoIt.Client.Models.Menus
{
	public class MenuItem
	{
		public string Title { get; set; }
		public EventCallback<MouseEventArgs> OnClick { get; set; }

	}
}
