using System;
using System.Globalization;
using Catel.MVVM.Converters;
using EnvCalc.BusinessObjects.ProduktManager;

namespace EnvCalc.Frontend.CustomControls.Converter
{
    public class ProduktToSingleStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return string.Empty;
            }

            var produkt = (Produkt) value;

            return string.Format("Produkt: {0} ({1}) - Erstellt: {2}", new object[]
            {
                produkt.Name, 
                produkt.Id, 
                produkt.Erstellungsdatum.ToString(CultureInfo.CurrentCulture)
            });
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}