using Kanban.Events;
using Kanban.Helpers;
using Kanban.Services.Api;
using Kanban.Services.Dialogs;
using Kanban.ViewModels.Items;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kanban.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private readonly IDialogsService _dialogsService;

        public MainPageViewModel(IEventAggregator eventAggregator,
            INavigationService navigationService,
            IApiService apiService,
            IDialogsService dialogsService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            _dialogsService = dialogsService;

            SelectActivityCommand = new DelegateCommand<ActivityItemViewModel>(async (selectedActivity) => await SelectActivity(selectedActivity));

            eventAggregator.GetEvent<NavigateEvent>()
                .Subscribe(Navigate);
        }

        private async Task SelectActivity(ActivityItemViewModel selectedActivity)
        {
            var parameters = new NavigationParameters();
            parameters.Add("SelectedActivity", selectedActivity);

            await _navigationService.NavigateAsync(NavigationConstants.EditActivity, parameters, true);
        }

        public ICommand SelectActivityCommand { get; set; }

        public ObservableCollection<ActivityItemViewModel> ToDo { get; set; }
        public ObservableCollection<ActivityItemViewModel> Doing { get; set; }
        public ObservableCollection<ActivityItemViewModel> Done { get; set; }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            await LoadData();
            base.OnNavigatedTo(parameters);
        }

        private async Task LoadData()
        {
            try
            {
                _dialogsService.ShowLoading();
                var result = await _apiService.GetAllActivities();

                ToDo = new ObservableCollection<ActivityItemViewModel>();
                Doing = new ObservableCollection<ActivityItemViewModel>();
                Done = new ObservableCollection<ActivityItemViewModel>();

                if (result.Response.IsSuccessStatusCode)
                {
                    foreach (var item in result.Data)
                    {
                        switch (item.State)
                        {
                            case Enumerations.ActivityState.ToDo:
                                ToDo.Add(ViewModelHelper.Get(item));
                                break;
                            case Enumerations.ActivityState.Doing:
                                Doing.Add(ViewModelHelper.Get(item));
                                break;
                            case Enumerations.ActivityState.Done:
                                Done.Add(ViewModelHelper.Get(item));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _dialogsService.ShowMessage("Error", "Ha ocurrido un error inesperado");
            }
            finally
            {
                _dialogsService.HideLoading();
            }
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
    }
}
