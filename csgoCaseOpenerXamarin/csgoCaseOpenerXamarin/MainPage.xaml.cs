using csgoCaseOpenerXamarin.Model;
using csgoCaseOpenerXamarin.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace csgoCaseOpenerXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            bankrolllbl.Text = $"{Bankroll.UserBankroll.ToString()} €";
        }

        private async void ButtonTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.CasesList());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            bankrolllbl.Text = $"{Bankroll.UserBankroll.ToString()} €";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryView());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EquipmentView());
        }
    }
}
