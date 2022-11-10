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

namespace WPF_saper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool start;
        const int maxX = 10, maxY = 10;
        int flagsLeft, bombsMarked, bombsNum;

        string[,] planszaWewn;
        Button[,] buttons;
        public MainWindow()
        {
            InitializeComponent();
            bombsNum = 10;
            flagsLeft = bombsNum;
            bombsMarked = 0;


            kom.Content = string.Format("Pozostało flag: {0}", flagsLeft.ToString());
            start = true;
            //                   [x   , y   ]
            planszaWewn = new string[maxX + 2, maxY + 2];
            for (int x = 0; x < maxX + 2; x++)
            {
                for (int y = 0; y < maxY + 2; y++)
                {
                    planszaWewn[x, y] = "";
                }
            }
            buttons = new Button[maxX, maxY];

            for (int x = 0; x < maxX; x++)
            {
                plansza.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int y = 0; y < maxY; y++)
            {
                plansza.RowDefinitions.Add(new RowDefinition());
            }

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    Button newBtn = new Button();
                    //newBtn.Click += Button_Click;
                    newBtn.PreviewMouseLeftButtonDown += Button_Click;
                    newBtn.PreviewMouseRightButtonDown += Button_Click_Bomb;
                    newBtn.Content = "";
                    Grid.SetColumn(newBtn, x);
                    Grid.SetRow(newBtn, y);

                    plansza.Children.Add(newBtn);
                    buttons[x, y] = newBtn;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            var button = sender as Button;
            int buttonX = Grid.GetColumn(button);
            int buttonY = Grid.GetRow(button);
            if (start)
            {
                placeBombs(buttonX, buttonY);
                start = false;
            } else
            {
                if (planszaWewn[buttonX + 1, buttonY + 1] == "0")
                {
                    buttons[buttonX, buttonY].Content = "0";


                    for (int x = buttonX - 1; x <= buttonX + 1; x++)
                    {
                        for (int y = buttonY - 1; y < buttonY + 1; y++)
                        {
                            if(x >= 0 && x <= 9 && y >= 0 && y <= 9 && !(y == buttonY && x == buttonX))
                            {
                                if (planszaWewn[buttonX + 1, buttonY + 1] == "0" && buttons[x, y].Content == "")
                                {
                                    buttons[x, y].Content = "0";
                                } else
                                {

                                }
                            }
                        }
                    }

                } else if (planszaWewn[buttonX + 1, buttonY + 1] == "b")
                {
                    buttons[buttonX, buttonY].Content = planszaWewn[buttonX + 1, buttonY + 1];
                    kom.Content = "Koniec - przegrałeś";
                    for (int x = 0; x < maxX; x++)
                    {
                        for (int y = 0; y < maxY; y++)
                        {
                            buttons[x, y].IsEnabled = false;
                        }
                    }

                }
                else
                {
                    buttons[buttonX, buttonY].Content = planszaWewn[buttonX + 1, buttonY + 1];
                }
            }
        }

        


        private void markZeroes(int locX, int locY)
        {
           

            //loc tutaj - dla planszy wewnętrznej
            /*int findMinY = 1, findMaxY = maxY + 1;

            for (int y = locY; y >= 1; y--)
            {
                if (planszaWewn[locX, y] != "0")
                {

                    findMinY = y;
                    break;
                }
            }
            for (int y = locY; y <= maxY + 1; y++)
            {
                if (planszaWewn[locX, y] != "0")
                {
                    findMaxY = y;
                    break;
                }
            }

            

            for (int y = findMinY; y < findMaxY; y++)
            {
                for (int x = locX; x >= 1; x--)
                {
                    if (planszaWewn[x, y] != "0")
                    {
                        //if (x > 0 && y > 0 && x < 10 && y < 10) buttons[x - 1, y - 1].Content = planszaWewn[x, y];
                        break;
                    } else
                    {
                        buttons[x - 1, y - 1].Content = planszaWewn[x, y];
                    }
                }
                for (int x = locX; x <= 11; x++)
                {
                    if (planszaWewn[x, y] != "0")
                    {

                        if (x > 0 && y > 0 && x < 10 && y < 10) {
                            buttons[x - 1, y - 1].Content = planszaWewn[x, y];
                        }
                        break;
                    }
                    else
                    {
                        buttons[x - 1, y - 1].Content = planszaWewn[x, y];
                    }
                }
            }*/
        }
        private void mark(int locX, int locY, string value)
        {
            if(value != "b") buttons[locX, locY].Content = value;

            //buttons[locX, locY].Content = value;
            planszaWewn[locX + 1, locY + 1] = value;
        }
        private bool checkIfSuitableBombPlace(int bombX, int bombY)
        {

            for (int i = bombX - 1; i <= bombX + 1; i++)
            {
                if(planszaWewn[i, bombY + 1] == "0" || planszaWewn[i, bombY - 1] == "0")
                {
                    return false;
                }

            }
            if (planszaWewn[bombX - 1, bombY] == "0" || planszaWewn[bombX + 1, bombY] == "0")
            {
                return false;
            }
            return true;
        }
        private void placeBombs(int zeroLocX, int zeroLocY)
        {
            mark(zeroLocX, zeroLocY, "0");

            /*for (int i = zeroLocX; i <= zeroLocX + 2; i++)
            {
                planszaWewn[i, zeroLocY + 2] = "0";
                planszaWewn[i, zeroLocY] = "0";
            }
            planszaWewn[zeroLocX, zeroLocY + 1] = "0";
            planszaWewn[zeroLocX + 2, zeroLocY + 1] = "0";*/
            //sprawdzanie od dołu


            Random r = new Random();
            int proposedLocX, proposedLocY;
            
            int bombsPlaced = 0;

            while(bombsPlaced < 10)
            {
                proposedLocX = r.Next(0, 10);
                proposedLocY = r.Next(0, 10);
                if (planszaWewn[proposedLocX + 1, proposedLocY + 1] == "" && checkIfSuitableBombPlace(proposedLocX + 1, proposedLocY + 1))
                {
                    mark(proposedLocX, proposedLocY, "b");
                    //planszaWewn[locX + 1, locY + 1] = "b";
                    bombsPlaced++;
                }
            }

            for (int x = 1; x < maxX + 1; x++)
            {
                for (int y = 1; y < maxY + 1; y++)
                {
                    if(planszaWewn[x, y] != "b" && planszaWewn[x, y] != "0")
                    {
                        int bombCount = 0;
                        //sprawdzanie na górę od pola
                        for (int i = x - 1; i <= x + 1; i++)
                        {
                            if (planszaWewn[i, y - 1] == "b") bombCount++;
                        }

                        //sprawdzanie po bokach
                        if (planszaWewn[x - 1, y] == "b") bombCount++;
                        if (planszaWewn[x + 1, y] == "b") bombCount++;
                        //sprawdzanie od dołu
                        for (int i = x - 1; i <= x + 1; i++)
                        {
                            if (planszaWewn[i, y + 1] == "b") bombCount++;
                        }

                        planszaWewn[x, y] = bombCount.ToString();
                        //buttons[x - 1, y - 1].Content = bombCount.ToString();
                    }
                }
            }
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            flagsLeft = 10;
            bombsMarked = 0;
            kom.Content = string.Format("Pozostało flag: {0}", flagsLeft.ToString());
            start = true;
            
            for (int x = 0; x < maxX + 2; x++)
            {
                for (int y = 0; y < maxY + 2; y++)
                {
                    planszaWewn[x, y] = "";
                }
            }
            
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    Button newBtn = new Button();
                    newBtn.PreviewMouseLeftButtonDown += Button_Click;
                    newBtn.PreviewMouseRightButtonDown += Button_Click_Bomb;

                    Grid.SetColumn(newBtn, x);
                    Grid.SetRow(newBtn, y);

                    plansza.Children.Add(newBtn);
                    buttons[x, y] = newBtn;
                }
            }
        }

        private void Button_Click_Bomb(object sender, RoutedEventArgs e)
        {
            
            var button = sender as Button;
            if (!start && flagsLeft > 0)
            {
                int buttonX = Grid.GetColumn(button);
                int buttonY = Grid.GetRow(button);
                flagsLeft--;
                kom.Content = string.Format("Pozostało flag: {0}", flagsLeft.ToString());
                if(planszaWewn[buttonX + 1, buttonY + 1] == "b")
                {
                    planszaWewn[buttonX + 1, buttonY + 1] = "o";
                    buttons[buttonX , buttonY].Content = "o";
                    bombsMarked++;
                    buttons[buttonX, buttonY].IsEnabled = false;
                }

            }
            if(flagsLeft <= 0)
            {
                if(bombsMarked == bombsNum)
                {
                    kom.Content = "Wygrałeś";
                } else
                {
                    kom.Content = "Koniec - przegrałeś";
                }
                
                for (int x = 0; x < maxX; x++)
                {
                    for (int y = 0; y < maxY; y++)
                    {
                        buttons[x, y].IsEnabled = false;
                    }
                }
            }
        }
    }
}
