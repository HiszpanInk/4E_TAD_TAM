using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace csgoCaseOpenerXamarin.Converters
{
    class IdToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 1) return "Blue";
            else if ((int)value == 2) return "Purple";
            else if ((int)value == 3) return "Pink";
            else if ((int)value == 4) return "Red";
            else if ((int)value == 5) return "Gold";
            else return "Black";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
