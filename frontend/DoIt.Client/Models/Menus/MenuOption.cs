using DoIt.Client.Models.Icons;
using System;

namespace DoIt.Client.Models.Menus
{
    public class MenuOption
	{
		public string Title { get; set; }

        public Action OnClick { get; set; }

        public IconType Icon { get; set; }

    }
}
