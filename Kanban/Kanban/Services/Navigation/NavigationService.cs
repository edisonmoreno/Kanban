using Kanban.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public void ChangeRoot(string key)
        {
            switch (key)
            {
                case "MasterPage":
                    App.Current.MainPage = new MasterPage();
                    break;
                case "LoginPage":
                    App.Current.MainPage = new LoginPage();
                    break;
                default:
                    break;
            }
        }

        public void GoBack()
        {
            
        }

        public void Navigate(string key)
        {
            
        }
    }
}
