using csgoCaseOpenerXamarin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace csgoCaseOpenerXamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CaseSkins : ContentPage
    {
        Case tempCase = new Case();
        /*public CaseSkins(Case CaseOne)
        {
            InitializeComponent();
            tempCase = CaseOne;
        }*/
        /* public CaseSkins(Case CaseOne)
         {
             InitializeComponent();

         }*/
        /*public CaseSkins(Case selectedCase)
        {
            InitializeComponent();

            skinsCollection.ItemsSource = Skin.skins.Where(s => s.Id_Case == selectedCase.Id).ToList();
            imageCase.Source = selectedCase.Link;
            textLbl.Text = $"Kup skrzynkę {selectedCase.Name} za {selectedCase.Price}€";
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if(Bankroll.UserBankroll >= tempCase.Price)
            {
                Bankroll.UserBankroll -= tempCase.Price;
                await Navigation.PushAsync(new CaseOpen(tempCase.Id));
            } else
            {
                await DisplayAlert("Uwaga!", "Niewystarczająca ilość środków na twoim koncie", "OK");
            }
           
        }
    }*/
        public CaseSkins(Case selectedCase)
        {
            InitializeComponent();
            tempCase = selectedCase;
            skinsCollection.ItemsSource = Skin.skins.Where(s => s.Id_Case == selectedCase.Id).ToList();
            caseImage.Source = tempCase.Link;
            caseLabel.Text = $"Kup {tempCase.Name} za {tempCase.Price}€";
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (Bankroll.UserBankroll >= tempCase.Price)
            {
                Bankroll.UserBankroll -= tempCase.Price;
                History h = new History();
                h.Id_Case = tempCase.Id;
                h.Id_Skin = 0;
                h.Price = tempCase.Price;
                h.Transcation = History.Typ.Kupno;
                await App.MyDatabase.CreateHistory(h);
                await Navigation.PushAsync(new CaseOpen(tempCase.Id));
            }
            else
            {
                await DisplayAlert("Uwaga", "Niewystarczająca ilość środków", "OK");
            }
        }
    }
}