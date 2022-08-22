using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DoIt.Client.Components.Fields
{
    public partial class SelectField : InputBase<string>
    {
        [Parameter]
        public IEnumerable<Option> Options { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool IsMandatory { get; set; }

        private string LabelView
        {
            get
            {
                return IsMandatory ? $"{Label}(*)" : Label;
            }
        }

        #region Overrides of InputBase<T>

        protected override bool TryParseValueFromString(string? value, out string result, out string? validationErrorMessage)
        {
            // todo: Look up value for label
            result = string.Empty;
            validationErrorMessage = null;
            return true;
        }
        #endregion
    }

    public class Option
    {
        public string Label { get; set; }

        public string Value { get; set; }
    }
}
