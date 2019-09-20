using Kanban.Helpers;
using Kanban.Services.Settings;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kanban.ViewModels
{
    public class LoginPageViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly ISettingsService _settingsService;

        private readonly ApplicationContext _context;

        public LoginPageViewModel(
            INavigationService navigationService,
            ISettingsService settingsService,
            ApplicationContext context)
        {
            _navigationService = navigationService;
            _settingsService = settingsService;

            _context = context;

            UserName = "Anónimo";
            //Se instancia la clase concreta segun el framework a usar
            StartCommand = new Command(Start);
        }

        private void Start()
        {
            _context.User = new Items.UserItemViewModel()
            {
                UserName = this.UserName,
            };

            _context.UseCloud = this.UseCloud;

            _settingsService.AddOrUpdateValue("UserName", this.UserName);
            _settingsService.AddOrUpdateValue("UseCloud", this.UseCloud);

            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("UserName", this.UserName);
            properties.Add("UseCloud", this.UseCloud.ToString());

            Analytics.TrackEvent("Login", properties);

            _navigationService.NavigateAsync(NavigationConstants.Main);
        }

        public string UserName { get; set; }
        public bool UseCloud { get; set; }
        public ICommand StartCommand { get; set; }
    }
}
