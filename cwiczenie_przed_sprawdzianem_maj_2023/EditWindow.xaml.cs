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
using static cwiczenie_przed_sprawdzianem_maj_2023.MainWindow;

namespace cwiczenie_przed_sprawdzianem_maj_2023
{
    /// <summary>
    /// Logika interakcji dla klasy EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        MainWindow parentWindow;
        sprawdzian_przedEntities db;
        int idInner;
        public EditWindow(MainWindow parentWindowTemp, int id)
        {
            parentWindow = parentWindowTemp;
            idInner = id;
            db = new sprawdzian_przedEntities();
            InitializeComponent();
            
            Ludzie ludz = db.Ludzies.Where(l => l.Id == id).Single();
            nameInput.Text = ludz.Name;
            surnameInput.Text = ludz.Surname;
            ageInput.Text = ludz.Wiek.ToString();
            genderInput.Text = "M";
            if ((bool)ludz.MK)
            {
                genderInput.Text = "K";
            }
            nameInput.Text = ludz.Name;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ludzie czlowiek = db.Ludzies.Single(l => l.Id == idInner);
            czlowiek.Name = nameInput.Text;
            czlowiek.Surname = surnameInput.Text;
            czlowiek.Wiek = int.Parse(ageInput.Text);
            czlowiek.MK = false;
            if (genderInput.Text == "K")
            {
                czlowiek.MK = true;
            }
            db.SaveChanges();
            parentWindow.RefreshData();
            Close();
        }
    }
}
