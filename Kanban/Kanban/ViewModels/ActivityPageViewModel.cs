using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kanban.Enumerations;
using Kanban.Helpers;
using Kanban.Services.Api;
using Kanban.Services.Dialogs;
using Kanban.ViewModels.Items;
using Prism.Commands;
using Prism.Navigation;

namespace Kanban.ViewModels
{
    public class ActivityPageViewModel : ViewModelBase
    {
        public ActionMode ActionMode { get; private set; }
        public ActivityItemViewModel SelectedActivity { get; set; }
        public ICommand SaveCommand { get; set; }

        private readonly IApiService _apiService;
        private readonly IDialogsService _dialogsService;

        public ActivityPageViewModel(
            INavigationService navigationService,
            IDialogsService dialogsService,
            IApiService apiService) : base(navigationService)
        {
            _apiService = apiService;
            _dialogsService = dialogsService;

            SaveCommand = new DelegateCommand(async () => await Save());
        }

        private async Task Save()
        {
            try
            {
                _dialogsService.ShowLoading();
                if (ActionMode == ActionMode.Create)
                {
                    var result = await _apiService.CreateActivity(ViewModelHelper.Get(SelectedActivity));
                    if (result.Response.IsSuccessStatusCode)
                    {
                        _dialogsService.ShowMessage("Exito", "Actividad creada.");
                        await NavigationService.GoBackAsync();
                    }
                    else
                    {
                        _dialogsService.ShowMessage("Error", "Ha ocurrido un error, revise su conexión.");
                    }
                }
                else if (ActionMode == ActionMode.Edit)
                {
                    var result = await _apiService.UpdateActivity(ViewModelHelper.Get(SelectedActivity));
                    if (result.Response.IsSuccessStatusCode)
                    {
                        _dialogsService.ShowMessage("Exito", "Actividad actualizada.");
                        await NavigationService.GoBackAsync();
                    }
                    else
                    {
                        _dialogsService.ShowMessage("Error", "Ha ocurrido un error, revise su conexión.");
                    }
                }
            }
            catch (Exception)
            {
                _dialogsService.ShowMessage("Error", "Ha ocurrido un error, revise su conexión.");
            }
            finally
            {
                _dialogsService.HideLoading();
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            ActionMode = (ActionMode)parameters["ActionMode"];

            if (ActionMode == ActionMode.Create)
                SelectedActivity = new ActivityItemViewModel();
            else
                SelectedActivity = (ActivityItemViewModel)parameters["SelectedActivity"];

            base.OnNavigatedTo(parameters);
        }

        
    }
}
