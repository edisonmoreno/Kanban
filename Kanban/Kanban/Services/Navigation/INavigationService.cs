using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Services.Navigation
{
    public interface INavigationService
    {
        void ChangeRoot(string key);
        void Navigate(string key);
        void GoBack();
    }
}
