using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Services.Settings
{
    public interface ISettingsService
    {
        bool AddOrUpdateValue(string key, bool value);
        bool AddOrUpdateValue(string key, DateTime value);
        bool AddOrUpdateValue(string key, decimal value);
        bool AddOrUpdateValue(string key, double value);
        bool AddOrUpdateValue(string key, float value);
        bool AddOrUpdateValue(string key, Guid value);
        bool AddOrUpdateValue(string key, int value);
        bool AddOrUpdateValue(string key, long value);
        bool AddOrUpdateValue(string key, string value);
        bool Contains(string key);
        void Delete(string key);
        bool GetValueOrDefault(string key, bool defaultValue);
        DateTime GetValueOrDefault(string key, DateTime defaultValue);
        decimal GetValueOrDefault(string key, decimal defaultValue);
        double GetValueOrDefault(string key, double defaultValue);
        float GetValueOrDefault(string key, float defaultValue);
        Guid GetValueOrDefault(string key, Guid defaultValue);
        int GetValueOrDefault(string key, int defaultValue);
        long GetValueOrDefault(string key, long defaultValue);
        string GetValueOrDefault(string key, string defaultValue);
    }
}
