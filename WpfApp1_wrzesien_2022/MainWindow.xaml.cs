using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1_wrzesien_2022
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //textBlock.Text = textBox.Text;
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //textBlock.FontSize = e.NewValue;
            //wartosc.Text = string.Format("{0:F2}", e.NewValue);
        }


        private void blue_Click(object sender, RoutedEventArgs e)
        {
            quote.Foreground = Brushes.Blue;
        }

        private void green_Click(object sender, RoutedEventArgs e)
        {
            quote.Foreground = Brushes.Green;
        }

        private void red_Click(object sender, RoutedEventArgs e)
        {
            quote.Foreground = Brushes.Red;
        }

        private void yellow_Click(object sender, RoutedEventArgs e)
        {
            quote.Foreground = Brushes.Yellow;
        }

        /*private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            textBlock.FontSize = slider.Value;
        }*/
    }
}
