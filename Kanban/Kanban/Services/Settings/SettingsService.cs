using Kanban.ViewModels.Items;
using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        public void Delete(string key)
        {
            CrossSettings.Current.Remove(key);
        }

        public decimal GetValueOrDefault(string key, decimal defaultValue)
        {
            return CrossSettings.Current.GetValueOrDefault(key, defaultValue);
        }

        public bool GetValueOrDefault(string key, bool defaultValue)
        {
            return CrossSettings.Current.GetValueOrDefault(key, defaultValue);
        }

        public long GetValueOrDefault(string key, long defaultValue)
        {
            return CrossSettings.Current.GetValueOrDefault(key, defaultValue);
        }

        public string GetValueOrDefault(string key, string defaultValue)
        {
            return CrossSettings.Current.GetValueOrDefault(key, defaultValue);
        }

        public int GetValueOrDefault(string key, int defaultValue)
        {
            return CrossSettings.Current.GetValueOrDefault(key, defaultValue);
        }

        public float GetValueOrDefault(string key, float defaultValue)
        {
            return CrossSettings.Current.GetValueOrDefault(key, defaultValue);
        }

        public DateTime GetValueOrDefault(string key, DateTime defaultValue)
        {
            return CrossSettings.Current.GetValueOrDefault(key, defaultValue);
        }

        public Guid GetValueOrDefault(string key, Guid defaultValue)
        {
            return CrossSettings.Current.GetValueOrDefault(key, defaultValue);
        }

        public double GetValueOrDefault(string key, double defaultValue)
        {
            return CrossSettings.Current.GetValueOrDefault(key, defaultValue);
        }

        public bool AddOrUpdateValue(string key, decimal value)
        {
            return CrossSettings.Current.AddOrUpdateValue(key, value);
        }

        public bool AddOrUpdateValue(string key, bool value)
        {
            return CrossSettings.Current.AddOrUpdateValue(key, value);
        }

        public bool AddOrUpdateValue(string key, long value)
        {
            return CrossSettings.Current.AddOrUpdateValue(key, value);
        }

        public bool AddOrUpdateValue(string key, string value)
        {
            return CrossSettings.Current.AddOrUpdateValue(key, value);
        }

        public bool AddOrUpdateValue(string key, int value)
        {
            return CrossSettings.Current.AddOrUpdateValue(key, value);
        }

        public bool AddOrUpdateValue(string key, float value)
        {
            return CrossSettings.Current.AddOrUpdateValue(key, value);
        }

        public bool AddOrUpdateValue(string key, DateTime value)
        {
            return CrossSettings.Current.AddOrUpdateValue(key, value);
        }

        public bool AddOrUpdateValue(string key, Guid value)
        {
            return CrossSettings.Current.AddOrUpdateValue(key, value);
        }

        public bool AddOrUpdateValue(string key, double value)
        {
            return CrossSettings.Current.AddOrUpdateValue(key, value);
        }

        public bool Contains(string key)
        {
            return CrossSettings.Current.Contains(key);
        }
    }
}