using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todo_app.classes;
using todo_app.pages;
using Xamarin.Forms;

namespace todo_app
{
    public partial class MainPage : ContentPage
    {
        JsonSO js = new JsonSO();
        public MainPage()
        {
            InitializeComponent();
            EventItem.List = js.OpenEventList();
            
            eventsItemListView.ItemsSource = EventItem.List;
        }

        private void eventsItemListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as EventItem;
            DisplayAlert(item.Subject, item.Info, "Zamknij");
        }

        private async void ToolbarItem_ClickedAdd(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEditPage(0));
        }

        private async void MenuItem_ClickedEdit(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            var events = item.CommandParameter as EventItem;
            await Navigation.PushAsync(new AddEditPage(events.Id));
        }

        private void MenuItem_ClickedDelete(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            var events = item.CommandParameter as EventItem;
            EventItem.List.Remove(events);
        }

        private void MenuItem_ClickedFinished(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            var events = item.CommandParameter as EventItem;
            EventItem.List.Remove(events);

            int id = 0;
            if(EventItem.ListDone.Any())
            {
                id = EventItem.ListDone.Max(x => x.Id);
            }
            id++;
            EventItem.ListDone.Add(new EventItem(id, events.Subject, events.Info));
        }

        private async void ToolbarItem_ClickedFinishedList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DoneList());
        }
    }
}
