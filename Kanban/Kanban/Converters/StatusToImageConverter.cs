using Kanban.Enumerations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Kanban.Converters
{
    public class StatusToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = value;

            switch (status)
            {
                default:
                case ActivityState.ToDo:
                    return "ic_to_do.png";
                case ActivityState.Doing:
                    return "ic_doing.png";
                case ActivityState.Done:
                    return "ic_done.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
