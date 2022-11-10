using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration;

namespace kolko_krzyk
{
    public partial class MainPage : ContentPage
    {
        bool rundaX;
        int doIluGier;
        int licznikGier;
        int rundaLicznik;
        int zwyciestwaX, zwyciestwaO, gry;

        string globwygrany;
        IList<Button> buttonList = new List<Button>();
        
        public MainPage()
        {
            InitializeComponent();
            rundaX = false;
            rundaLicznik = 0;
            zwyciestwaX = 0;
            zwyciestwaO = 0;
            licznikGier = 0;
            globwygrany = " ";


            doIlu();
            for (int i = 0; i < 9; i++)
            {
                buttonList.Add(new Button());
                buttonList[i].Clicked += Button_Clicked;
                buttonList[i].ClassId = i.ToString();
                buttonList[i].Text = " ";
                buttonList[i].FontSize = 52;
            }
            int a = 0;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {               
                    plansza.Children.Add(buttonList[a], x, y);
                    a++;
                }
            }
        }
        private void rundaStart()
        {
            rundaX = false;
            rundaLicznik = 0;
            runda.Text = "Startuje O";

            for (int i = 0; i < 9; i++)
            {
                buttonList[i].Text = " ";
                buttonList[i].FontSize = 52;
                buttonList[i].IsEnabled = true;
                buttonList[i].BackgroundColor = Color.Default;
            }
        }
        async void nastepna()
        {
            
            if (licznikGier == doIluGier)
            {
                string komunikat = "";
                if (zwyciestwaO == zwyciestwaX)
                {
                    komunikat = "Ostatecznie - remis";
                }
                else if (zwyciestwaX > zwyciestwaO)
                {
                    komunikat = "Ostatecznie wygrywa X";
                }
                else if (zwyciestwaX < zwyciestwaO)
                {
                    komunikat = "Ostatecznie wygrywa O";
                }
                await DisplayAlert("Alert", komunikat, "OK");
                doIlu();
                licznikGier = 0;

                zwyciestwaX = 0;
                zwyciestwaO = 0;
                rundaStart();
            } else
            {
                await DisplayAlert("Alert", globwygrany, "OK");
                //await DisplayAlert("Alert", "Następna gra", "OK");
                rundaStart();
            }
        }
        async void doIlu()
        {
            string result = await DisplayPromptAsync("Question 1", "Do ilu chcesz grać?");
            doIluGier = int.Parse(result);
        }
        private void czyWygrana()
        {
            string wygrany = "";
            bool czyKoniec = false;
            bool czyDefinitywnyKoniec = false;
            IList<int> checkXWins = new List<int> { 1, 4, 7 };
            IList<int> checkYWins = new List<int> { 3, 4, 5 };
            IList<int> checkVerticalWin1 = new List<int> { 0, 8 };
            IList<int> checkVerticalWin2 = new List<int>{2, 6};

            foreach(int x in checkXWins)
            {
                if(buttonList[x].Text != " ")
                {
                    if ((buttonList[x - 1].Text == buttonList[x].Text) && (buttonList[x + 1].Text == buttonList[x].Text))
                    {
                        czyKoniec = true;
                        wygrany = buttonList[x].Text;
                    }
                }
            }
            

            if(czyKoniec == false)
            {
      
                    foreach (int y in checkYWins)
                    {
                    if (buttonList[y].Text != " ")
                    {
                        if ((buttonList[y - 3].Text == buttonList[y].Text) && (buttonList[y + 3].Text == buttonList[y].Text))
                        {
                            czyKoniec = true;
                            wygrany = buttonList[y].Text;
                        }
                    }
                }
            }


            if (!czyKoniec)
            {
                if (buttonList[4].Text != " ")
                {
                    if (buttonList[checkVerticalWin1[0]].Text == buttonList[4].Text && buttonList[checkVerticalWin1[1]].Text == buttonList[4].Text)
                    {
                        czyKoniec = true;
                        wygrany = buttonList[4].Text;
                    }
                }
            }
            if (!czyKoniec)
            {
                if (buttonList[4].Text != " ")
                {

                    if (buttonList[checkVerticalWin2[0]].Text == buttonList[4].Text && buttonList[checkVerticalWin2[1]].Text == buttonList[4].Text)
                    {
                        czyKoniec = true;
                        wygrany = buttonList[4].Text;
                    }
                }
            }
            

            if (czyKoniec == true)
            {
                runda.Text = String.Format("Wygrywa {0}", wygrany);
                for (int i = 0; i < 9; i++)
                { 
                    buttonList[i].IsEnabled = false;
                }
                if(wygrany == "X")
                {
                    zwyciestwaX++;
                    
                } else if (wygrany == "O")
                {
                    zwyciestwaO++;
                }
                globwygrany = String.Format("Wygrywa {0}", wygrany);
                wynik.Text = String.Format("O: {0} - {1}:X", zwyciestwaO, zwyciestwaX);
                gry++;
                licznikGier++;
                czyDefinitywnyKoniec = true;
            }
            if(rundaLicznik == 8 && czyKoniec == false)
            {
                runda.Text = "Remis";
                globwygrany = " ";
                gry++;
                licznikGier++;
                czyDefinitywnyKoniec = true;
            }
            if (czyDefinitywnyKoniec)
            {
                runda.Text = "Koniec";
                nastepna();

            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (rundaX)
            {
                button.Text = "X";
                button.BackgroundColor = Color.Orange;
                runda.Text = "Teraz O";
                rundaX = !rundaX;
                foreach(Button btn in buttonList)
                {
                    if(btn.Text == " ")
                    {
                        btn.BackgroundColor = Color.Sienna;
                    }
                }
            } else
            {
                button.Text = "O";
                button.BackgroundColor = Color.Navy;
                runda.Text = "Teraz X";
                rundaX = !rundaX;
                foreach (Button btn in buttonList)
                {
                    if (btn.Text == " ")
                    {
                        btn.BackgroundColor = Color.Wheat;
                    }
                }
            }
            button.IsEnabled = false;
            czyWygrana();
            rundaLicznik++;
        }
    }
}
