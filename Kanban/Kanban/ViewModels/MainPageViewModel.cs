using Kanban.Enumerations;
using Kanban.Events;
using Kanban.Helpers;
using Kanban.Models;
using Kanban.Services.Api;
using Kanban.Services.Dialogs;
using Kanban.Services.LocalDatabase;
using Kanban.Services.Settings;
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
        private readonly ISettingsService _settingsService;
        private readonly ApplicationContext _context;
        private readonly ILocalDatabaseService _localDatabaseService;

        public MainPageViewModel(IEventAggregator eventAggregator,
            INavigationService navigationService,
            ISettingsService settingsService,
            ApplicationContext context,
            ILocalDatabaseService localDatabaseService,
            IApiService apiService,
            IDialogsService dialogsService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            _dialogsService = dialogsService;
            _settingsService = settingsService;
            _context = context;

            SelectActivityCommand = new DelegateCommand<ActivityItemViewModel>(async (selectedActivity) => await SelectActivity(selectedActivity));
            AddNewActivityCommand = new DelegateCommand(() => Navigate("NewActivity"));

            eventAggregator.GetEvent<NavigateEvent>()
                .Subscribe(Navigate);
        }

        private async Task SelectActivity(ActivityItemViewModel selectedActivity)
        {
            var parameters = new NavigationParameters();
            parameters.Add("SelectedActivity", selectedActivity);
            parameters.Add("ActionMode", ActionMode.Edit);

            await _navigationService.NavigateAsync(NavigationConstants.Activity, parameters);
        }

        public ICommand SelectActivityCommand { get; set; }
        public ICommand AddNewActivityCommand { get; set; }

        public ObservableCollection<ActivityItemViewModel> ToDo { get; set; }
        public ObservableCollection<ActivityItemViewModel> Doing { get; set; }
        public ObservableCollection<ActivityItemViewModel> Done { get; set; }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            //if (parameters.GetNavigationMode() == NavigationMode.Back)
            await LoadData();

            base.OnNavigatedTo(parameters);
        }

        private async Task LoadData()
        {
            try
            {
                _dialogsService.ShowLoading();
                List<ActivityModel> result;
                if (_context.UseCloud)
                {
                    var response = await _apiService.GetAllActivities();
                    result = response.Data;
                }
                else
                    result = await _localDatabaseService.GetAllActivities();

                ToDo = new ObservableCollection<ActivityItemViewModel>();
                Doing = new ObservableCollection<ActivityItemViewModel>();
                Done = new ObservableCollection<ActivityItemViewModel>();

                foreach (var item in result)
                {
                    switch ((ActivityState)item.State)
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
                case "NewActivity":
                    var parameters = new NavigationParameters();
                    parameters.Add("ActionMode", ActionMode.Create);
                    _navigationService.NavigateAsync(NavigationConstants.Activity, parameters);
                    break;
                case "About":
                    _navigationService.NavigateAsync(NavigationConstants.About);
                    break;
                case "Exit":
                    _settingsService.Delete("UseCloud");
                    _settingsService.Delete("UserName");
                    _navigationService.NavigateAsync(NavigationConstants.Loader);
                    break;
                default:
                    break;
            }
        }
    }
}
