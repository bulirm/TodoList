using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TodoList.Converters
{
    class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime? || value is null)
            {
                DateTime? date = (DateTime?)value;
                string output = "Deadline: ";
                output += date == null ? "without deadline" : $"{date?.Day}.{date?.Month}.{date?.Year}";
                return output;
            }
            throw new Exception("Wrong value type!");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
