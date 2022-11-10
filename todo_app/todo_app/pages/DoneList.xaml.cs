using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todo_app.classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace todo_app.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DoneList : ContentPage
    {
        JsonSO js = new JsonSO();
        public DoneList()
        {
            InitializeComponent();
            EventItem.ListDone = js.OpenEventListDone();
            eventsItemListView.ItemsSource = EventItem.ListDone;
        }

        private void MenuItem_ClickedRevive(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            var events = item.CommandParameter as EventItem;
            EventItem.ListDone.Remove(events);

            int id = 0;
            if (EventItem.List.Any())
            {
                id = EventItem.List.Max(x => x.Id);
            }
            id++;
            EventItem.List.Add(new EventItem(id, events.Subject, events.Info));
        }

        private void MenuItem_ClickedDelete(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            var events = item.CommandParameter as EventItem;
            EventItem.ListDone.Remove(events);
        }

        private void eventsItemListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as EventItem;
            DisplayAlert(item.Subject, item.Info, "Zamknij");
        }
    }
}