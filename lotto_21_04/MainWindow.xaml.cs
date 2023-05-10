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

namespace lotto_21_04
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        lottoEntities db = new lottoEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int[] liczba;
            for (int y = 0; y < 10; y++)
            {
                liczba = new int[6];
                Console.WriteLine(liczba[3]);
                
                for (int i = 0; i < 6; i++)
                {
                    bool checkNum = false;
                    while(!checkNum)
                    {
                        checkNum = true;
                        int liczbaLos = rnd.Next(1, 50);
                        for (int x = 0; x < i; x++)
                        {
                            if (liczbaLos == liczba[x])
                            {
                                checkNum = false;
                            }
                        }
                        if (checkNum)
                        {
                            liczba[i] = liczbaLos;
                        }
                    }
                }

                Array.Sort(liczba);
                NewTable newSet = new NewTable()
                {
                    liczba1 = liczba[0],
                    liczba2 = liczba[1],
                    liczba3 = liczba[2],
                    liczba4 = liczba[3],
                    liczba5 = liczba[4],
                    liczba6 = liczba[5],
                };
                db.NewTables.Add(newSet);

            }
            db.SaveChanges();
            wynik.Content = "Wylosowano!";
           //wynik.Content = (liczba[0]).ToString() + " " + (liczba[1]).ToString() + " " + (liczba[2]).ToString() + " " + (liczba[3]).ToString() + " " + (liczba[4]).ToString() + " " + (liczba[5]).ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool result = false;
            List<NewTable> lista  = db.NewTables
                .OrderByDescending(x => x.Id)
                .Take(10)
                .ToList();
            int[] userInput = new int[6];
            userInput[0] = int.Parse(input1.Text);
            userInput[1] = int.Parse(input2.Text);
            userInput[2] = int.Parse(input3.Text);
            userInput[3] = int.Parse(input4.Text);
            userInput[4] = int.Parse(input5.Text);
            userInput[5] = int.Parse(input6.Text);
            input1.Text = "";
            input2.Text = "";
            input3.Text = "";
            input4.Text = "";
            input5.Text = "";
            input6.Text = "";
            Array.Sort(userInput);
            foreach (var set in lista)
            {
                if(userInput[0] == set.liczba1 && userInput[1] == set.liczba2 && userInput[2] == set.liczba3 && userInput[3] == set.liczba4 && userInput[4] == set.liczba5 && userInput[5] == set.liczba6)
                {
                    result = true;
                    break;
                }
            }
            if(result)
            {
                wynik.Content = "Poprawny zestaw!";
            } else
            {
                wynik.Content = "Niestety nie udało się zmieścić w zakresie toleracji";
            }

        }
    }
}
