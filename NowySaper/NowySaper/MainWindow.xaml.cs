using System;
using System.Collections.Generic;
using System.Data.Common;
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

namespace NowySaper
{
    public partial class MainWindow : Window
    {
        Random random = new();
        OwnButton[,] buttons = new OwnButton[10, 10];
        public int licznikAll = 100, licznikP = 10;
        public bool firstClick = false;
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                field.RowDefinitions.Add(new RowDefinition());
                field.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    buttons[i, j] = new();
                    field.Children.Add(buttons[i, j]);
                    Grid.SetColumn(buttons[i, j], j);
                    Grid.SetRow(buttons[i, j], i);
                    buttons[i, j].Click += Button_Clicked;
                    buttons[i, j].MouseRightButtonDown += Button_Selected;
                }
            }

            int counter = 0;
            while (counter < 10)
            {
                int row = random.Next(10);
                int column = random.Next(10);

                if (buttons[row, column].Value != 10)
                {
                    buttons[row, column].Value = 10;
                    for (int i = row - 1; i <= row + 1; i++)
                    {
                        for (int j = column - 1; j <= column + 1; j++)
                        {
                            if (i >= 0 && i <= 9 && j >= 0 && j <= 9)
                            {
                                if (buttons[i, j].Value < 10)
                                {
                                    buttons[i, j].Value++;
                                }
                            }
                        }
                    }
                    counter++;
                }
            }
        }
        private bool PierwszyRuch(int w, int k)
        {
            for (int i = w - 1; i <= w + 1; i++)
            {
                for (int j = k - 1; j <= k + 1; j++)
                {
                    if (i >= 0 && i <= 9 && j >= 0 && j <= 9)
                    {
                        buttons[i, j].Value = 100;  
                    }
                }
            }
            int counter = 0;
            while (counter < 10)
            {
                int row = random.Next(10);
                int column = random.Next(10);

                if (buttons[row, column].Value < 10)
                {
                    buttons[row, column].Value = 10;
                    for (int i = row - 1; i <= row + 1; i++)
                    {
                        for (int j = column - 1; j <= column + 1; j++)
                        {
                            if (i >= 0 && i <= 9 && j >= 0 && j <= 9)
                            {
                                if (buttons[i, j].Value < 10)
                                {
                                    buttons[i, j].Value++;
                                } else if (buttons[i, j].Value >= 100)
                                {
                                    buttons[i, j].Value++;
                                }
                            }
                        }
                    }
                    counter++;
                }
            }
            for (int i = w - 1; i <= w + 1; i++)
            {
                for (int j = k - 1; j <= k + 1; j++)
                {
                    if (i >= 0 && i <= 9 && j >= 0 && j <= 9)
                    {
                        buttons[i, j].Value -= 100;
                    }
                }
            }
            return true;
        }
        private void Show(int row, int column)
        {
            if(buttons[row, column].Flag)
            {
                buttons[row, column].Content = "💣";
            }
            else
            {
                buttons[row, column].Content = buttons[row, column].Value.ToString();
            }
            
            buttons[row, column].Showed = true;

            licznikAll--;   

            buttons[row, column].IsEnabled = false;

            if (buttons[row, column].Value == 0)
            {
                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = column - 1; j <= column + 1; j++)
                    {
                        if (i >= 0 && i <= 9 && j >= 0 && j <= 9 && !(i == row && j == column))
                        {
                            if (buttons[i, j].Value == 0 && buttons[i, j].Showed == false)
                            {
                                Show(i, j);
                            }
                            else
                            {
                                if(buttons[i, j].Showed == false)
                                {
                                    licznikAll--;
                                }
                                buttons[i, j].Content = buttons[i, j].Value.ToString();
                                buttons[i, j].Showed = true;
                                
                            }
                        }
                    }
                }
            }
            else if (buttons[row, column].Value == 10)
            {
                ShowAll();
            }
        }

        private void ShowAll()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if(buttons[i, j].Value == 10)
                    {
                        buttons[i, j].Content = "💣";
                        if(buttons[i, j].Flag)
                        {
                            buttons[i, j].Background = Brushes.Red;
                        }
                    }
                    else 
                    { 
                        buttons[i, j].Content = buttons[i, j].Value.ToString();
                    }
                }
            }
        }

        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            int senderRow = Grid.GetRow((OwnButton)sender);
            int senderColumn = Grid.GetColumn((OwnButton)sender);
            if(!firstClick)
            {
                firstClick = PierwszyRuch(senderRow, senderColumn);
            }
            Show(senderRow, senderColumn);
            Ruchy.Content = licznikAll.ToString();
            if (licznikAll == 0) ShowAll();
        }

        private void Button_Selected(object sender, MouseButtonEventArgs e)
        {
            int senderRow = Grid.GetRow((OwnButton)sender);
            int senderColumn = Grid.GetColumn((OwnButton)sender);
            if(!buttons[senderRow, senderColumn].Flag)
            {
                if(licznikP > 0)
                {
                    licznikP--;
                    licznikAll--;
                    buttons[senderRow, senderColumn].Flag = true;
                    buttons[senderRow, senderColumn].Content = "🚩";
                }
            }
            else
            {
                licznikP++;
                licznikAll++;
                buttons[senderRow, senderColumn].Flag = false;
                buttons[senderRow, senderColumn].Content = "";
            }
        }
    }
}
