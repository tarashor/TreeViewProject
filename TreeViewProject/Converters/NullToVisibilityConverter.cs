using System;
using System.Windows;
using System.Windows.Data;

namespace TreeViewProject.Converters
{
    /// <summary>
    /// Represents the class that converts <c>null</c> value to the <c>Visibility.Collapsed</c> value.
    /// </summary>
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
