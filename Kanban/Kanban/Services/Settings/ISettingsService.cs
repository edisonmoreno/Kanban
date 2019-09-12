using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Services.Settings
{
    public interface ISettingsService
    {
        void Save(string key, string value);
        string Get(string key);
    }
}
