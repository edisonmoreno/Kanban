using Kanban.ViewModels.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.ViewModels
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
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

        public List<ActivityItemViewModel> ToDo { get; set; }
        public List<ActivityItemViewModel> Doing { get; set; }
        public List<ActivityItemViewModel> Done { get; set; }
    }
}
