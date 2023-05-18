using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace cwiczenie_przed_sprawdzianem_maj_2023
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        sprawdzian_przedEntities db;
        public struct czlowiek
        {
            public int id { get; set; }
            public string NameSurname { get; set; }
            public int Wiek { get; set; }
            public char Plec { get; set; }

            public czlowiek(int id, string nameSurname, int wiek, char plec)
            {
                this.id = id;
                NameSurname = nameSurname;
                Wiek = wiek;
                Plec = plec;
            }
        }
        public ObservableCollection<czlowiek> getLudzieToDisplay()
        {
            ObservableCollection<czlowiek> toReturn = new ObservableCollection<czlowiek>();
            foreach(var item in new ObservableCollection<Ludzie>(db.Ludzies.ToList()))
            {
                char gender = 'M';
                if(((bool)item.MK))
                {
                    gender = 'K';
                }
                toReturn.Add(new czlowiek(item.Id, $"{item.Name} {item.Surname}", (int)item.Wiek, gender));
            }

            return toReturn;
        }
        public void RefreshData()
        {
            peopleGrid.ItemsSource = null;
            peopleGrid.ItemsSource = getLudzieToDisplay();
        }
        public MainWindow()
        {
            db = new sprawdzian_przedEntities();
            InitializeComponent();
            RefreshData();
          
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddWindow add = new AddWindow(this);
            add.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            czlowiek czlowiek = (czlowiek)peopleGrid.SelectedItem;
            Ludzie ludz = db.Ludzies.Where(a => a.Id == czlowiek.id).Single();
            db.Ludzies.Remove(ludz);
            db.SaveChanges();
            RefreshData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            czlowiek czlowiek = (czlowiek)peopleGrid.SelectedItem;
            EditWindow edit = new EditWindow(this, czlowiek.id);
            edit.Show();
            
        }
    }
}
