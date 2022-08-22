using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DoIt.Client.Components.Fields
{
    public partial class TextField : InputBase<string>
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool Multiline { get; set; }

        [Parameter]
        public Expression<Func<string>> ValidationFor { get; set; }

        [Parameter]
        public bool IsMandatory { get; set; }

        [Parameter]
        public string Width { get; set; }

        [Parameter]
        public string InitialValue { get; set; }

        [Parameter]
        public IEnumerable<string> AutocompleteOptions { get; set; } = new List<string>();

        private IEnumerable<string> FilteredAutocompleteOptions
        {
            get
            {
                return string.IsNullOrEmpty(CurrentValue) ? AutocompleteOptions : AutocompleteOptions.Where(x => x.StartsWith(CurrentValue) && x != CurrentValue);
            }
        }

        private bool HasLabel
        {
            get
            {
                return !string.IsNullOrEmpty(Label);
            }
        }

        private string LabelView
        {
            get
            {
                return IsMandatory ? $"{Label}(*)" : Label;
            }
        }

        private bool IsDisplayAutocomplete
        {
            get
            {
                return FilteredAutocompleteOptions.Any() && (_isFieldFocused || _isAutocompleteHovered);
            }
        }

        private bool _isFieldFocused = false;
        private bool _isAutocompleteHovered = false;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (string.IsNullOrEmpty(Width))
            {
                Width = "auto";
            }

            this.Value = InitialValue;
        }

        protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }

        private void OnFocusInField(FocusEventArgs args)
        {
            _isFieldFocused = true;
            StateHasChanged();
        }

        private void OnFocusOutField(FocusEventArgs args)
        {
            _isFieldFocused = false;
            StateHasChanged();
        }

        private void OnFieldInputEvent(ChangeEventArgs changeEvent)
        {
            CurrentValue = (string)changeEvent.Value;
        }

        private void OnAutocompleteMouseOver(MouseEventArgs args)
        {
            _isAutocompleteHovered = true;
            StateHasChanged();
        }

        private void OnAutocompleteMouseOut(MouseEventArgs args)
        {
            _isAutocompleteHovered = false;
            StateHasChanged();
        }

        private void SelectOption(string optionText)
        {
            CurrentValue = optionText;
            _isAutocompleteHovered = false;
            StateHasChanged();
        }
    }
}
