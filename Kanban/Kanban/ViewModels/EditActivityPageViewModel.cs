using System;
using System.Collections.Generic;
using System.Text;
using Kanban.ViewModels.Items;
using Prism.Navigation;

namespace Kanban.ViewModels
{
    public class EditActivityPageViewModel : ViewModelBase
    {
        public EditActivityPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            SelectedActivity = (ActivityItemViewModel)parameters["SelectedActivity"];
            base.OnNavigatedTo(parameters);
        }

        public ActivityItemViewModel SelectedActivity { get; set; }
    }
}
