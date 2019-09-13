using Kanban.Events;
using Kanban.Helpers;
using Kanban.ViewModels.Items;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Kanban.ViewModels
{
    public class MasterPageViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public MasterPageViewModel(
            INavigationService navigationService,
            IEventAggregator eventAggregator,
            ApplicationContext context)
        {
            User = context.User;
            Items = new List<MenuItemViewModel>();

            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            Items.Add(new MenuItemViewModel()
            {
                Title = "Reiniciar",
                Icon = "ic_done.png",
                ActionKey = "Restart",
                Description = "Establecer todas las actividades en pendiente"
            });

            Items.Add(new MenuItemViewModel()
            {
                Title = "Borrar todo",
                Icon = "ic_done.png",
                ActionKey = "DeleteAll",
                Description = "Eliminar todas las tareas"
            });

            Items.Add(new MenuItemViewModel()
            {
                Title = "Acerca de Kanban",
                Icon = "ic_done.png",
                ActionKey = "About",
                Description = "Conocer más sobre los desarrolladores"
            });

            Items.Add(new MenuItemViewModel()
            {
                Title = "Salir",
                Icon = "ic_done.png",
                ActionKey = "Exit",
                Description = "Cerrar sesión"
            });

            ExecuteActionCommand = new DelegateCommand<MenuItemViewModel>(ExecuteAction);
        }

        private void ExecuteAction(MenuItemViewModel item)
        {
            _eventAggregator.GetEvent<NavigateEvent>().Publish(item.ActionKey);
        }

        public UserItemViewModel User { get; set; }
        public List<MenuItemViewModel> Items { get; set; }
        public ICommand ExecuteActionCommand { get; set; }
    }
}
