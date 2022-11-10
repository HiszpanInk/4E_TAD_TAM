using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarinPages4e1
{
    public partial class MainPage : FlyoutPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            flyout.list.ItemSelected += OnSelectedItem;
        }

        private async void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutItemPage;
            if(item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                flyout.list.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
