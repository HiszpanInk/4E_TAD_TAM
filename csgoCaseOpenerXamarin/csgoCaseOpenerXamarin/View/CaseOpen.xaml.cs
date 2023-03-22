using csgoCaseOpenerXamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Color = Xamarin.Forms.Color;

namespace csgoCaseOpenerXamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CaseOpen : CarouselPage
    {
        Model.Skin temp = new Model.Skin();
        Random random = new Random();
        ObservableCollection<Model.Skin> winSkin = new ObservableCollection<Model.Skin>();

        Image image;
        Label labelName;
        Label labelPrice;
        StackLayout stackLayout;
        ContentPage contentPage;
        int win;

        public CaseOpen(int id)
        {
            InitializeComponent();

            foreach (var skin in Model.Skin.skins.Where(s => s.Id_Case == id).ToList())
            {
                for (int i = 0; i < skin.Id_Color; i++)
                {
                    winSkin.Add(skin);
                }
            }

            for (int i = 0; i < 500; i++)
            {
                int index1 = random.Next(winSkin.Count());
                int index2 = random.Next(winSkin.Count());
                temp = winSkin[index1];
                winSkin[index1] = winSkin[index2];
                winSkin[index2] = temp;
            }

            foreach (var skin in winSkin)
            {
                Color color = new Color();
                switch (skin.Id_Color)
                {
                    case 1:
                        color = Color.Blue;
                        break;
                    case 2:
                        color = Color.MediumPurple;
                        break;
                    case 3:
                        color = Color.DeepPink;
                        break;
                    case 4:
                        color = Color.Red;
                        break;
                    case 5:
                        color = Color.Gold;
                        break;
                    default:
                        break;
                }

                image = new Image
                {
                    Source = skin.Link,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = 300,
                    HeightRequest = 300,
                };

                labelName = new Label
                {
                    Text = skin.Name,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 30,
                };

                labelPrice = new Label
                {
                    Text = $"{skin.Price}€",
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    FontSize = 24,
                    FontAttributes = FontAttributes.Bold,
                };

                stackLayout = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                };

                stackLayout.Children.Add(image);
                stackLayout.Children.Add(labelName);
                stackLayout.Children.Add(labelPrice);

                contentPage = new ContentPage
                {
                    BackgroundColor = color,
                };

                contentPage.Content = stackLayout;

                carousel.Children.Add(contentPage);
            }
            win = random.Next(winSkin.Count());
            int licznik = 0;
            bool timer = true;
            if (timer) Device.StartTimer(new TimeSpan(0, 0, 0, 0, 250), () =>
            {
                // do something every 60 seconds
                Device.BeginInvokeOnMainThread(() =>
                {
                    // interact with UI elements
                    if (licznik <= win)
                    {
                        this.CurrentPage = this.Children[licznik];
                    }
                    else
                    {
                        timer = false;
                    }
                    licznik++;
                });
                if(!timer)
                {
                    OnAlertYesNoClicked(winSkin[win]);
                }
                return timer; // runs again, or false to stop
            });
        }
        async void OnAlertYesNoClicked(Skin skin)
        {
            bool answer = await DisplayAlert($"{skin.Name}", $"Cena: {skin.Price}€. Co chcesz zrobić?", "Zachowaj", "Sprzedaj");
            if(answer)
            {
                Equipment eq = new Equipment();
                eq.Id_Skin = winSkin[win].Id;
                await App.MyDatabase.CreateEquipment(eq);

                History h = new History();
                h.Id_Skin = winSkin[win].Id;
                h.Price = winSkin[win].Price;
                h.Transcation = History.Typ.Gratis;
                await App.MyDatabase.CreateHistory(h);

                await Navigation.PopAsync();
            } else
            {
                Bankroll.UserBankroll += skin.Price;

                History h = new History();
                h.Id_Skin = winSkin[win].Id;
                h.Price = winSkin[win].Price;
                h.Transcation = History.Typ.Sprzedaż;
                await App.MyDatabase.CreateHistory(h);

                await Navigation.PopAsync();
            }
        }
            protected override bool OnBackButtonPressed() => true;
        }
    }

