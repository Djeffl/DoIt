using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Linq.Expressions;

namespace DoIt.Client.Components.Fields
{
	public partial class TextField : InputBase<string>
	{
		[Parameter]
		public string Label { get; set; }

		[Parameter]
		public bool Multiline  { get; set; }

		[Parameter] 
		public Expression<Func<string>> ValidationFor { get; set; }

		[Parameter]
		public bool IsMandatory { get; set; }

		[Parameter]
		public string Width { get; set; }
		
		[Parameter]
		public string InitialValue { get; set; }

		private string LabelView
		{
			get
			{
				return IsMandatory ? $"{Label}(*)" : Label;
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();

			if (string.IsNullOrEmpty(Width))
			{
				Width = "320px";
			}

			this.Value = InitialValue;
		}

		protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
		{
			result = value;
			validationErrorMessage = null;
			return true;
		}
	}
}
