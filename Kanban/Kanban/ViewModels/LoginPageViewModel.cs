using Kanban.Helpers;
using Kanban.Services.Settings;
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
                UserName = this.UserName
            };

            _settingsService.Save("User", this.UserName);
            _navigationService.NavigateAsync(NavigationConstants.Main);
        }

        //public string Username { get; set; }

        private string userName;

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        public ICommand StartCommand { get; set; }
    }
}
