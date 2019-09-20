using System;
using System.Collections.Generic;
using System.Text;
using Kanban.Models;
using Kanban.ViewModels.Items;

namespace Kanban.Helpers
{
    public static class ViewModelHelper
    {
        internal static ActivityItemViewModel Get(ActivityModel activity)
        {
            return new ActivityItemViewModel()
            {
                Id = activity.Id,
                Date = activity.Date,
                Time = activity.Date.TimeOfDay,
                Description = activity.Description,
                Title = activity.Title,
                State = activity.State,
            };
        }

        internal static ActivityModel Get(ActivityItemViewModel activity)
        {
            return new ActivityModel()
            {
                Id = activity.Id,
                Date = activity.Date.Date.Add(activity.Time),
                Description = activity.Description,
                Title = activity.Title,
                State = activity.State,
            };
        }
    }
}
