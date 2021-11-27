using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace DoIt.Client.Models.Menus
{
	public class MenuOption
	{
		public string Title { get; set; }
		public Task<EventCallback> OnClick { get; set; }
	}
}
