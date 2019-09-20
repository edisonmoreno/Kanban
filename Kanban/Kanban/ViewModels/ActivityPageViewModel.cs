using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kanban.Enumerations;
using Kanban.Helpers;
using Kanban.Services.Api;
using Kanban.Services.Dialogs;
using Kanban.Services.LocalDatabase;
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

        private readonly ApplicationContext _context;
        private readonly IApiService _apiService;
        private readonly IDialogsService _dialogsService;
        private readonly ILocalDatabaseService _localDatabaseService;

        public ActivityPageViewModel(
            INavigationService navigationService,
            ILocalDatabaseService localDatabaseService,
            IDialogsService dialogsService,
            IApiService apiService,
            ApplicationContext context) : base(navigationService)
        {
            _apiService = apiService;
            _dialogsService = dialogsService;
            _localDatabaseService = localDatabaseService;
            _context = context;

            SaveCommand = new DelegateCommand(async () => await Save());
        }

        public string Title
        {
            get
            {
                if (_context.UseCloud)
                {
                    switch (this.ActionMode)
                    {
                        case ActionMode.Create:
                            return "Create in cloud";
                        case ActionMode.Edit:
                            return "Edit in cloud";
                    }
                }
                else
                {
                    switch (this.ActionMode)
                    {
                        case ActionMode.Create:
                            return "Create locally";
                        case ActionMode.Edit:
                            return "Edit locally";
                    }
                }

                return string.Empty;
            }
        }
        private async Task Save()
        {
            try
            {
                _dialogsService.ShowLoading();
                if (_context.UseCloud)
                    await SaveInCloud();
                else
                    await SaveInLocalDatabase();
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

        private async Task SaveInLocalDatabase()
        {
            if (ActionMode == ActionMode.Create)
            {
                SelectedActivity.Id = Guid.NewGuid().ToString();
                await _localDatabaseService.CreateActivity(ViewModelHelper.Get(SelectedActivity));
                _dialogsService.ShowMessage("Exito", "Actividad creada.");
                await NavigationService.GoBackAsync();
            }
            else if (ActionMode == ActionMode.Edit)
            {
                await _localDatabaseService.UpdateActivity(ViewModelHelper.Get(SelectedActivity));
                _dialogsService.ShowMessage("Exito", "Actividad actualizada.");
                await NavigationService.GoBackAsync();
            }
        }

        private async Task SaveInCloud()
        {
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
