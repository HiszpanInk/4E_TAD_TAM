using kartkowka_mobilne_1_1.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace kartkowka_mobilne_1_1.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}