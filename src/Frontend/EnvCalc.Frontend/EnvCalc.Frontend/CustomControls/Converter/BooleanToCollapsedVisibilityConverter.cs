using System;
using System.Globalization;
using System.Windows;
using Catel.MVVM.Converters;

namespace EnvCalc.Frontend.CustomControls.Converter
{
    public class BooleanToCollapsedVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //reverse conversion (false=>Visible, true=>collapsed) on any given parameter
            var input = value != null && (null == parameter ? (bool)value : !(bool)value);
            return input ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}