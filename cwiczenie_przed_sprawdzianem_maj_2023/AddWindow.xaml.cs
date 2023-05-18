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
using System.Windows.Shapes;

namespace cwiczenie_przed_sprawdzianem_maj_2023
{
    /// <summary>
    /// Logika interakcji dla klasy AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        MainWindow maintest2;
        public AddWindow(MainWindow maintest)
        {
            InitializeComponent();
            maintest2 = maintest;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sprawdzian_przedEntities db = new sprawdzian_przedEntities();
            Ludzie czlowiek = new Ludzie();
            czlowiek.Name = nameInput.Text;
            czlowiek.Surname = surnameInput.Text;
            czlowiek.Wiek = int.Parse(ageInput.Text);
            czlowiek.MK = false;
            if (genderInput.Text == "K")
            {
                czlowiek.MK = true;
            }
            db.Ludzies.Add(czlowiek);
            db.SaveChanges();
            maintest2.RefreshData();
            Close();
        }
    }
}
