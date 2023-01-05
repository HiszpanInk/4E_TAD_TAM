using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarin_collection_view_05_01
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Filmy> filmy;
        public MainPage()
        {
            InitializeComponent();
            filmy = new ObservableCollection<Filmy>
            {
                new Filmy{Nazwa = "Szklana pułapka", Zdjecie = "https://fwcdn.pl/fpo/12/70/1270/7382745.3.jpg", Kategoria = Filmy.Group.Akcja },
                new Filmy{Nazwa = "Avatar", Zdjecie = "https://fwcdn.pl/fpo/91/13/299113/8028716.3.jpg", Kategoria = Filmy.Group.Dramat },
                new Filmy{Nazwa = "Żywot Briana", Zdjecie = "https://upload.wikimedia.org/wikipedia/en/1/18/Lifeofbrianfilmposter.jpg", Kategoria = Filmy.Group.Komedia },
                new Filmy{Nazwa = "Piła", Zdjecie = "https://fwcdn.pl/fpo/14/13/121413/7538066.3.jpg", Kategoria = Filmy.Group.Horror },
            };
            myCollectionView.ItemsSource = filmy;
        }

        private void SwipeItem_Invoked(object sender, EventArgs e)
        {
            //Filmy doUsuniecia = sender as Filmy;
            //filmy.Remove(doUsuniecia);
        }

        private void SwipeItem_Invoked_1(object sender, EventArgs e)
        {

        }

        private void myCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.CurrentSelection.Any())
            {
                StringBuilder sb = new StringBuilder();
                foreach (var current in e.CurrentSelection)
                {
                    Filmy t = current as Filmy;
                    sb.AppendLine($"{t.Nazwa} : {t.Kategoria}");
                }
                DisplayAlert("Filmy", $"{sb.ToString()}", "OK");
            }
            /*
            ObservableCollection<Filmy> temp = new ObservableCollection<Filmy>();
            foreach(var current in e.CurrentSelection)
            {
                Filmy t = current as Filmy;
                temp.Add(t);
            }

            if(temp.Any())
            {
                StringBuilder sb = new StringBuilder();
                foreach (var filmy in temp)
                {
                    sb.AppendLine($"{filmy.Nazwa} : {filmy.Kategoria}");
                }
                DisplayAlert("Filmy", $"{sb.ToString()}", "OK");
            }
            /*
            var itemSelected = e.CurrentSelection[0] as Filmy;
            if(itemSelected != null)
            {
                DisplayAlert($"{itemSelected.Nazwa}", $"{itemSelected.Kategoria}", "OK");
            }
            */
        }

        private void SwipeItem_Invoked_2(object sender, EventArgs e)
        {
            DisplayAlert("komunikat", "dodano do ulubionych", "OK");
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filteredList = filmy.Where(a => a.Nazwa.StartsWith(e.NewTextValue));
            myCollectionView.ItemsSource = filteredList;
        }
    }
}