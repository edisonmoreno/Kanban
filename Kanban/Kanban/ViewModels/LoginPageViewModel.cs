using Kanban.Services.Navigation;
using Kanban.Services.Settings;
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
        public LoginPageViewModel()
        {
            //Esto no se hace, no tenemos aun inyector de dependencias
            _navigationService = new NavigationService();
            _settingsService = new SettingsService();

            UserName = "Anónimo";
            //Se instancia la clase concreta segun el framework a usar
            StartCommand = new Command(Start);
        }

        private void Start()
        {
            _settingsService.Save("User", this.UserName);
            _navigationService.ChangeRoot("MasterPage");
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
