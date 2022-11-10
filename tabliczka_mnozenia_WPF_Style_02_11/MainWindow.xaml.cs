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

namespace tabliczka_mnozenia_WPF_Style_02_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int maxX = 12, maxY = 12;
        bool isFirst;
        int locationX, locationY;
        Label[,] labels;
        public MainWindow()
        {
            InitializeComponent();
            List<Button> buttonListX = new List<Button>();
            List<Button> buttonListY = new List<Button>();
            labels = new Label[maxX, maxY];


            isFirst = true;
            plansza.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 1; i < maxX + 1; i++)
            {
                plansza.ColumnDefinitions.Add(new ColumnDefinition());
                Button newBtn = new Button();
                newBtn.Click += Button_Click;
                Grid.SetRow(newBtn, 0);
                Grid.SetColumn(newBtn, i);
                newBtn.Content = i.ToString();
                plansza.Children.Add(newBtn);
                buttonListX.Add(newBtn);
            }
            plansza.RowDefinitions.Add(new RowDefinition());
            for (int i = 1; i < maxY + 1; i++)
            {
                plansza.RowDefinitions.Add(new RowDefinition());
                Button newBtn = new Button();
                newBtn.Click += Button_Click;
                Grid.SetRow(newBtn, i);
                Grid.SetColumn(newBtn, 0);
                newBtn.Content = i.ToString();
                
                plansza.Children.Add(newBtn);
                buttonListY.Add(newBtn);
            }

            for (int x = 1; x < maxX + 1; x++)
            {
                for (int y = 1; y < maxY + 1; y++)
                {
                    Label newLbl = new Label();
                    newLbl.Content = (x * y).ToString();
                    Grid.SetRow(newLbl, y);
                    Grid.SetColumn(newLbl, x);
                    newLbl.Style = this.FindResource("defaultLabel") as Style;
                    labels[x - 1, y - 1] = newLbl;
                    plansza.Children.Add(newLbl);
                }
            }
        }

        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    labels[x, y].Style = this.FindResource("defaultLabel") as Style;
                }
            }
            isFirst = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    labels[x, y].Style = this.FindResource("defaultLabel") as Style;
                }
            }
            var button = sender as Button;
            
            int column = Grid.GetColumn(button);
            int row = Grid.GetRow(button);
           
            if(column == 0)
            {
                locationY = row - 1;
            }
            if (row == 0)
            {
                locationX = column - 1;
            }

            if (!isFirst)
            {
                for (int x = 0; x < locationX; x++)
                {
                    labels[x, locationY].Style = this.FindResource("showedLabel") as Style;
                }
                for (int y = 0; y < locationY; y++)
                {
                    labels[locationX, y].Style = this.FindResource("showedLabel") as Style;
                }

                labels[locationX, locationY].Style = this.FindResource("showedLabel") as Style;
                //isFirst = true;
            } else
            {
                isFirst = false;
                
            }
        }
    }
}
