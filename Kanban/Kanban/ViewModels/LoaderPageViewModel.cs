using Kanban.Helpers;
using Kanban.Services.Settings;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kanban.ViewModels
{
    public class LoaderPageViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly ApplicationContext _context;

        public LoaderPageViewModel(
            ApplicationContext context,
            INavigationService navigationService,
            ISettingsService settingsService) : base(navigationService)
        {
            _settingsService = settingsService;
            _context = context;
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            await Task.Delay(1000);

            bool useCloud = _settingsService.GetValueOrDefault("UseCloud", false);
            string UserName = _settingsService.GetValueOrDefault("UserName", null);

            if (string.IsNullOrEmpty(UserName))
            {
                await NavigationService.NavigateAsync(NavigationConstants.Login);
            }
            else
            {
                _context.UseCloud = useCloud;
                _context.User = new Items.UserItemViewModel()
                {
                    UserName = UserName
                };

                await NavigationService.NavigateAsync(NavigationConstants.Main);
            }

            base.OnNavigatedTo(parameters);
        }
    }
}
