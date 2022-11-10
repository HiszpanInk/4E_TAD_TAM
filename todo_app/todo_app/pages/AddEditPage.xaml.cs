using System;
using System.Linq;
using todo_app.classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace todo_app.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditPage : ContentPage
    {
        int id_ = 0;
        public AddEditPage(int id)
        {
            InitializeComponent();
            if(id == 0)
            {
                AddEdit.Title = "Dodaj nową pozycję do listy";
            } else
            {
                id_ = id;
                AddEdit.Title = "Edytuj pozycję z listy";
                EventItem item = EventItem.List.Single(x => x.Id == id);
                subjectEntry.Text = item.Subject;
                infoEditor.Text = item.Info;
                
            }
        }

        private async void button_Clicked(object sender, EventArgs e)
        {
            if(id_ != 0)
            {
                EventItem item = EventItem.List.Single(x => x.Id == id_);
                EventItem.List.Remove(item);
            }

            int id = 0;
            if (EventItem.List.Any())
            {
                id = EventItem.List.Max(x => x.Id);

            }
            id++;
            EventItem.List.Add(new EventItem(id, subjectEntry.Text, infoEditor.Text));
            await Navigation.PopAsync();
        }
    }
} 