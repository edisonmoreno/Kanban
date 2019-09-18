using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Services.Dialogs
{
    public class DialogsService : IDialogsService
    {
        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }

        public bool ShowConfirmation(string title, string message, string acceptText, string cancelText)
        {
            throw new NotImplementedException();
        }

        public void ShowLoading()
        {
            UserDialogs.Instance.ShowLoading();
        }

        public void ShowMessage(string title, string message)
        {
            UserDialogs.Instance.AlertAsync(message, title, "Ok");
        }
    }
}
