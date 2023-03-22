using System;
using System.Globalization;
using Xamarin.Forms;
using csgoCaseOpenerXamarin.Model;

namespace csgoCaseOpenerXamarin.Converters
{
    internal class TransactionToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var transaction = (History.Typ)value;
            if (transaction == History.Typ.Sprzedaż) return "Green";
            if (transaction == History.Typ.Kupno) return "Red";
            if (transaction == History.Typ.Gratis) return "Gold";
            return "white";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
