using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace todoAppDatabase
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditPage : ContentPage
    {
        int selectedPriority;
        TodoEntryModel tempEntry = null;
        public AddEditPage()
        {
            InitializeComponent();
            selectedPriority = 0;
            btn.Text = "Dodaj";
            btn.Clicked += Button_Clicked;
        }
        public AddEditPage(TodoEntryModel todoEntryModel)
        {
            InitializeComponent();
            contentInput.Text = todoEntryModel.EntryContent;
            dateInput.Date = todoEntryModel.Date;
            noDate.IsChecked = !todoEntryModel.hasDate;
            switch (todoEntryModel.Priority)
            {
                case 0:
                    lowPriority.IsChecked= true;
                    break;
                case 1:
                    mediumPriority.IsChecked = true;
                    break;
                case 2:
                    highPriority.IsChecked = true;
                    break;
            }
            tempEntry = todoEntryModel;
            btn.Text = "Edytuj";
            btn.Clicked += Button_Clicked_Edit;
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if(lowPriority.IsChecked== true)
            {
                selectedPriority = 0;
            } else if (mediumPriority.IsChecked == true) {
                selectedPriority = 1;
            }
            else if (highPriority.IsChecked == true)
            {
                selectedPriority = 2;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            DateTime newDate = DateTime.Today;
            if(!noDate.IsChecked)
            {
                newDate = dateInput.Date;
            }
            await App.MyDatabase.CreateEntry(new TodoEntryModel { EntryContent=contentInput.Text, hasDate = !noDate.IsChecked, Date = newDate, Priority=selectedPriority });
            await Navigation.PopAsync();
        }
        private async void Button_Clicked_Edit(object sender, EventArgs e)
        {
            tempEntry.EntryContent = contentInput.Text;
            tempEntry.hasDate = !noDate.IsChecked;
            if(tempEntry.hasDate)
            {
                tempEntry.Date = dateInput.Date;
            } else
            {
                tempEntry.Date = DateTime.Today;
                dateInput.IsVisible = false;
            }
            
            tempEntry.Priority = selectedPriority;
            await App.MyDatabase.UpdateEntry(tempEntry);
            await Navigation.PopAsync();
        }

        

        private void noDate_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if(noDate.IsChecked == true)
            {
                dateInput.IsEnabled= false;
                dateInput.IsVisible= false;
            } else
            {
                dateInput.IsEnabled= true;
                dateInput.IsVisible= true;
            }
        }
    }
}