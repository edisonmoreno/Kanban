using Kanban.ViewModels.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.ViewModels
{
    public class ApplicationContext
    {
        public UserItemViewModel User { get; set; }
        public bool UseCloud { get; internal set; }
    }
}
