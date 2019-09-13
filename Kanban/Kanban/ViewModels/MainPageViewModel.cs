using Kanban.Events;
using Kanban.Helpers;
using Kanban.ViewModels.Items;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.ViewModels
{
    public class MainPageViewModel
    {
        private readonly INavigationService _navigationService;

        public MainPageViewModel(IEventAggregator eventAggregator,
            INavigationService navigationService)
        {
            _navigationService = navigationService;

            eventAggregator.GetEvent<NavigateEvent>().Subscribe(Navigate);

            ToDo = new List<ActivityItemViewModel>()
            {
                new ActivityItemViewModel()
                {
                    Title = "Todo 1",
                    Description = "Lorem ipsum",
                    DateTime = DateTime.Now
                }
            };

            Doing = new List<ActivityItemViewModel>()
            {
                new ActivityItemViewModel()
                {
                    Title = "Doing 1",
                    Description = "Lorem ipsum",
                    DateTime = DateTime.Now
                }
            };

            Done = new List<ActivityItemViewModel>()
            {
                new ActivityItemViewModel()
                {
                    Title = "Done 1",
                    Description = "Lorem ipsum",
                    DateTime = DateTime.Now
                }
            };
        }

        private void Navigate(string actionKey)
        {
            switch (actionKey)
            {
                case "About":
                    _navigationService.NavigateAsync(NavigationConstants.About);
                    break;
                case "Exit":
                    _navigationService.NavigateAsync(NavigationConstants.Login);
                    break;
                default:
                    break;
            }
        }

        public List<ActivityItemViewModel> ToDo { get; set; }
        public List<ActivityItemViewModel> Doing { get; set; }
        public List<ActivityItemViewModel> Done { get; set; }
    }
}
