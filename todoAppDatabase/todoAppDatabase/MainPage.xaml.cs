using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace todoAppDatabase
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //App.MyDatabase.ResetTable();
           
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                viewWithDate.ItemsSource = null;
                viewWithDate.ItemsSource = await App.MyDatabase.ReadEntriesDate();
                viewWithoutDate.ItemsSource = null;
                viewWithoutDate.ItemsSource = await App.MyDatabase.ReadEntriesNoDate();
            }
            catch { }
        }
        public async void Refresh()
        {
            viewWithDate.ItemsSource = null;
            viewWithDate.ItemsSource = await App.MyDatabase.ReadEntriesDate();
            viewWithoutDate.ItemsSource = null;
            viewWithoutDate.ItemsSource = await App.MyDatabase.ReadEntriesNoDate();
            
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEditPage());
        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var entry = item.CommandParameter as TodoEntryModel;
            await App.MyDatabase.DeleteEntry(entry);
            Refresh();
        }

        private async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var entry = item.CommandParameter as TodoEntryModel;
            await Navigation.PushAsync(new AddEditPage(entry));
        }
    }
}
