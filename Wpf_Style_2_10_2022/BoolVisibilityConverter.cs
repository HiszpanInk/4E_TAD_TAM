using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Wpf_Style_2_10_2022
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    internal class BoolVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isVisible = (bool)value;
            if(isVisible)
            {
                return Visibility.Visible;
                //return "Visible";
            } else
            {
                return Visibility.Collapsed;
                //return "Collapsed";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
