using System;
using System.Collections.Generic;
using System.Text;
using Kanban.Models;
using Kanban.ViewModels.Items;

namespace Kanban.Helpers
{
    public static class ViewModelHelper
    {
        internal static ActivityItemViewModel Get(ActivityModel item)
        {
            return new ActivityItemViewModel()
            {
                Id = item.Id,
                Date = item.Date,
                Time = item.Date.TimeOfDay,
                Description = item.Description,
                Title = item.Title,
                State = item.State,
            };
        }
    }
}
