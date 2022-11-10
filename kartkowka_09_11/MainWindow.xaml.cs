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

namespace kartkowka_09_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btn1.Content = "";
            btn2.Content = "";
            btn3.Content = "";
            btn4.Content = "";
            

        }
        private void setButtonColorMost()
        {
            Random r = new Random();
            Button[] buttons = new Button[4];
            int[] kolory = new int[4];
            for(int i = 0; i < 4; i++)
            {
                kolory[i] = 0;
            }
            buttons[0] = btn1;
            buttons[1] = btn2;
            buttons[2] = btn3;
            buttons[3] = btn4;
            
            foreach(Button button in buttons)
            {
                if(button.Content != "")
                {
                    kolory[int.Parse(button.Content.ToString()) - 1] += 1;
                }
            }
            int max = 0;
            List<int> possibleColors = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                if(kolory[i] > max)
                {
                    max = kolory[i];
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (kolory[i] == max)
                {
                    possibleColors.Add(i);
                }
            }

            switch (possibleColors[r.Next(possibleColors.Count)])
            { 
                case 0:
                    wylosuj.Background = Brushes.Red;
                    break;
                case 1:
                    wylosuj.Background = Brushes.Blue;
                    break;
                case 2:
                    wylosuj.Background = Brushes.Green;
                    break;
                case 3:
                    wylosuj.Background = Brushes.Yellow;
                    break;
            }
        }

        private void checkAll()
        {
            if(btn1.Content.ToString() == btn2.Content.ToString() && btn3.Content.ToString() == btn4.Content.ToString() && btn1.Content.ToString() == btn4.Content.ToString())
            {
                btn1.IsEnabled = false;
                btn2.IsEnabled = false;
                btn3.IsEnabled = false;
                btn4.IsEnabled = false;
            }
            setButtonColorMost();
        }
        
        private void Button_Click_Wylosuj(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            btn1.Content = (r.Next(1, 5)).ToString();
            btn2.Content = (r.Next(1, 5)).ToString();
            btn3.Content = (r.Next(1, 5)).ToString();
            btn4.Content = (r.Next(1, 5)).ToString();
            checkAll();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            var button = sender as Button;
            button.Content = (r.Next(1, 5)).ToString();
            checkAll();
        }
    }
}
