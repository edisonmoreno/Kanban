using Kanban.ViewModels.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.ViewModels
{
    public class MenuPageViewModel
    {
        public MenuPageViewModel()
        {
            Items = new List<MenuItemViewModel>();
            Items.Add(new MenuItemViewModel()
            {
                Title = "Titulo de ejemplo",
                Icon = string.Empty,
                ActionKey = "SampleAction",
                Description = "Description larga de la acción a realizar"
            });

            Items.Add(new MenuItemViewModel()
            {
                Title = "Titulo de ejemplo 2",
                Icon = string.Empty,
                ActionKey = "SampleAction2",
                Description = "Description larga de la acción a realizar 2"
            });
        }
        public List<MenuItemViewModel> Items { get; set; }
    }
}
