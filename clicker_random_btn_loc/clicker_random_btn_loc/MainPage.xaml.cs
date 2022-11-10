using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace clicker_random_btn_loc
{
    public partial class MainPage : ContentPage
    {
        Button btn, resetButton;
        int clicker;
        Random rnd;
        int seconds;
        TapGestureRecognizer kliknieciePozaPrzyciskiem;

        double deviceWidth;
        double length;

        int countdownStartValue;
        int missclickPenalty;
        //Timer timer;
        public MainPage()
        {
            InitializeComponent();
            start();
            
        }
        async void start()
        {
            //
            //przygotowywanie planszy
            deviceWidth = DeviceDisplay.MainDisplayInfo.Width;

            length = deviceWidth / 5;

            top.HeightRequest = 100;
            plansza.HeightRequest = DeviceDisplay.MainDisplayInfo.Height - 100;
            //time.Text = length.ToString();
            for (int i = 0; i < 10; i++)
            {
                /*newRD = new RowDefinition();
                newRD.Height = length;
                plansza.RowDefinitions.Add(newRD);*/

                plansza.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < 5; i++)
            {
                /*newCD = new ColumnDefinition();
                newCD.Width = length;
                plansza.ColumnDefinitions.Add(new ColumnDefinition());*/

                plansza.ColumnDefinitions.Add(new ColumnDefinition());
            }
            kliknieciePozaPrzyciskiem = new TapGestureRecognizer();
            
            plansza.GestureRecognizers.Add(kliknieciePozaPrzyciskiem);
            btn = new Button();
            btn.Text = "Start";
            btn.Clicked += Start;
            btn.HeightRequest = length;
            btn.WidthRequest = length;
            plansza.Children.Add(btn, 2, 5);
            clicker = 0;
            rnd = new Random();
            countdownStartValue = 10;
            seconds = countdownStartValue;
            missclickPenalty = 2;
            await countdownStartingPointInput();
            await missclickPenaltyInput();
        }
        public async Task countdownStartingPointInput()
        {
            countdownStartValue = int.Parse(await DisplayPromptAsync("Question 1", "Podaj czas na starcie:"));
            seconds = countdownStartValue;
            time.Text = string.Format("Czas: {0}", seconds.ToString());
        }
        public async Task missclickPenaltyInput()
        {
            int input = int.Parse(await DisplayPromptAsync("Question 2", "Podaj karę za nietrafienie:"));
            missclickPenalty = input;
            
        }
        private void click()
        {
            clicker++;
            counter.Text = string.Format("Wynik: {0}", clicker.ToString());
            seconds++;
            time.Text = string.Format("Czas: {0}", seconds.ToString());
        }
        private void moveButton()
        {
            plansza.Children.Remove(btn);
            //btn.HeightRequest = length * rnd.Next(1, 3);
            //btn.WidthRequest = length * rnd.Next(1, 3);
            plansza.Children.Add(btn, rnd.Next(0, 5), rnd.Next(0, 10));
        }
        private void Start(object sender, EventArgs e)
        {
            moveButton();
            btn.Clicked -= Start;
            btn.Clicked += Button_Clicked;
            kliknieciePozaPrzyciskiem.Tapped += missClicked;
            btn.Text = "";
            
            StartTimer();
        }
        private void StartTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                seconds--;
                time.Text = string.Format("Czas: {0}", seconds.ToString());
                if(seconds <= 0)
                {
                    stop();
                    return false;
                } else
                {
                    return true;
                }
            });
        }
        private void stop()
        {
            time.Text = "Czas: 0";
            moveButton();
            btn.Text = "STOP";
            btn.IsEnabled = false;
            btn.Clicked -= Button_Clicked;
            kliknieciePozaPrzyciskiem.Tapped -= missClicked;
            resetButton = new Button();
            resetButton.Text = "Restart";
            resetButton.Clicked += restart;
            resetButton.IsVisible = true;
            plansza.Children.Add(resetButton, 2, 5);
            plansza.Children.Remove(btn);
        
        }
        private void restart(object sender, EventArgs e)
        {
            resetButton.IsVisible = false;
            plansza.Children.Add(btn, rnd.Next(0, 5), rnd.Next(0, 10));

            seconds = countdownStartValue;
            time.Text = string.Format("Czas: {0}", seconds.ToString());
            clicker = 0;
            counter.Text = string.Format("Wynik: {0}", clicker.ToString());
            btn.Text = "";
            btn.IsEnabled = true;
            btn.Clicked += Button_Clicked;
            kliknieciePozaPrzyciskiem.Tapped += missClicked;
            StartTimer();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            moveButton();
            click();
        }
        private void missClicked(object sen, EventArgs e)
        {
            seconds -= missclickPenalty;
            if (seconds <= 0)
            {
                string.Format("Wynik: 0");
            }else
            {
                time.Text = string.Format("Czas: {0}", seconds.ToString());
            }
            
            clicker = 0;
            counter.Text = string.Format("Wynik: {0}", clicker.ToString());
        }
    }
}
