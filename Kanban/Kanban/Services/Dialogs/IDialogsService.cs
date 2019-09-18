using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Services.Dialogs
{
    public interface IDialogsService
    {
        void ShowMessage(string title, string message);
        bool ShowConfirmation(string title, string message, string acceptText, string cancelText);
        void ShowLoading();
        void HideLoading();
    }
}
