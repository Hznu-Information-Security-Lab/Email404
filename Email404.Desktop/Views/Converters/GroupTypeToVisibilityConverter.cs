using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Email404.Desktop.Views.Converters
{
    public class GroupTypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Collapsed;
            
            string groupType = value.ToString();
            bool isInverse = parameter != null && parameter.ToString() == "Inverse";
            
            if (isInverse)
            {
                return groupType == "custom" ? Visibility.Collapsed : Visibility.Visible;
            }
            
            return groupType == "custom" ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 