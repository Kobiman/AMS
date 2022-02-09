using Microsoft.AspNetCore.Components;
using System;

namespace AMS.Client
{
    public class ToastService
    {
        public string Message { get; set; }
        public string AlertType { get; set; }

        public void UpdateState(string type, string message)
        {
            Message = message;
            AlertType = type;
        }

        public event EventHandler<ToastServiceEventAgrs> ToastOpened;
        public virtual void ShowAlert(ComponentBase source, string type, string message)
        {
            ToastOpened?.Invoke(source, new ToastServiceEventAgrs(type, message));
        }

        public event EventHandler<ToastServiceEventAgrs> ToastClosed;
        public virtual void CloseAlert(ComponentBase source)
        {
            ToastClosed?.Invoke(source, new ToastServiceEventAgrs("", ""));
        }
    }

    public class ToastServiceEventAgrs : EventArgs
    {
        public string Type { get; set; }
        public string Message { get; set; }

        public ToastServiceEventAgrs(string type, string message)
        {
            Type = type;
            Message = message;
        }
    }
}
