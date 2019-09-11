using Kanban.ViewModels.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        public string Get(string key)
        {
            return null;
        }

        public void Save(string key, string value)
        {
            if (key == "User")
            {
                var cache = (UserItemViewModel)App.Current.Resources["LoggedInUser"];
                cache.Username = value;
            }
        }
    }
}
