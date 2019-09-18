using System;
using System.Collections.Generic;
using System.Text;
using Kanban.Enumerations;

namespace Kanban.ViewModels.Items
{
    public class ActivityItemViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public TimeSpan Time { get; set; }
        public ActivityState State { get; set; }
        public DateTime Date { get; internal set; }
    }
}
