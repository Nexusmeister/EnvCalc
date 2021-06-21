using System;
using System.Globalization;
using Catel.MVVM.Converters;
using EnvCalc.BusinessObjects.Enums;

namespace EnvCalc.Frontend.CustomControls.Converter
{
    public class BooleanToInputOutputConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return Enum.GetName(typeof(ExchangeRichtung), ExchangeRichtung.Undefined);
            }

            var input = null == parameter ? (bool)value : !(bool)value;
            var enumValue = input ? ExchangeRichtung.Input : ExchangeRichtung.Output;
            var result = Enum.GetName(typeof(ExchangeRichtung), enumValue);

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}