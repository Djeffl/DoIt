using DoIt.Client.Models.Toasts;
using Microsoft.AspNetCore.Components;
using System;

namespace DoIt.Client.Services.Toast
{
    public class ToastService
    {
        public event Action<ToastLevel, string, string> OnShow;

        public ToastService()
        {
        }

        public void ShowInfo(string message, string header = "")
        {
            OnShow?.Invoke(ToastLevel.Info, message, header);
        }

        public void ShowSuccess(string message, string header = "")
        {
            OnShow?.Invoke(ToastLevel.Success, message, header);
        }

        public void ShowError(string message, string header = "")
        {
            OnShow?.Invoke(ToastLevel.Error, message, header);
        }

        public void ShowWarning(string message, string header = "")
        {
            OnShow?.Invoke(ToastLevel.Warn, message, header);
        }
    }
}
