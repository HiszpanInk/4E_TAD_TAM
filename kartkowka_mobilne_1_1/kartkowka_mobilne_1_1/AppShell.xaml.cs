using kartkowka_mobilne_1_1.ViewModels;
using kartkowka_mobilne_1_1.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace kartkowka_mobilne_1_1
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
