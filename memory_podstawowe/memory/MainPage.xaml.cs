using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Timers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Runtime.Serialization.Json;

namespace memory
{

    public partial class MainPage : ContentPage
    {
        //private static System.Timers.Timer aTimer;
        //                         [Y, X]
        Button[,] btns = new Button[5, 4];
        int[,] numbers = new int[5, 4];

        struct cardLoc
        {
            public int x;
            public int y;
        }

        //w sumie te tablice to bym na proste structy zamienił, tak dla wygody
        cardLoc turnedCard1Loc;
        cardLoc turnedCard2Loc;
        
        int znalezionePary;
        bool isOneAlreadyTurned;
        public MainPage()
        {
            InitializeComponent();
            isOneAlreadyTurned = false;
            znalezionePary = 0;
            var rnd = new Random();
            //tworzenie tablicy z liczbami
            int[] tempNumbers = new int[20];

            int pom = 0;
            for(int i = 0; i < 2; i++)
            {
                for (int num = 0; num < 10; num++)
                {
                    tempNumbers[pom] = num;
                    pom++;
                }
            }
            //randomomizowanie kolejności liczb
            tempNumbers = tempNumbers.OrderBy(x => rnd.Next()).ToArray();
            //tworzenie przycisków i oddawanie ich na planszę oraz tworzenie dwuwymiarowej tablicy z liczbami
            int a = 0;
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    numbers[y, x] = tempNumbers[a];
                    a++;
                    btns[y, x] = new Button();
                    btns[y, x].Clicked += Button_Clicked;
                    btns[y, x].BackgroundColor = Color.Turquoise;

                    plansza.Children.Add(btns[y, x], x, y);
                   
                }
            }
            /*
            //to wyświetlanie tych numerków jest tylko do testu
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    btns[y, x].Text = (numbers[y, x]).ToString();
                }
            }*/
        }
        public void odwroc(int btnY, int btnX)
        {
            if(btns[btnY, btnX].IsEnabled == true)
            {
                btns[btnY, btnX].BackgroundColor = Color.Default;
                btns[btnY, btnX].IsEnabled = false;
                btns[btnY, btnX].Text = (numbers[btnY, btnX]).ToString();
            } else
            {
                btns[btnY, btnX].BackgroundColor = Color.Turquoise;
                btns[btnY, btnX].IsEnabled = true;
                btns[btnY, btnX].Text = "";
            }
        }
        public void odznaczKarte(int btnY, int btnX)
        {
            btns[btnY, btnX].Text = "";
            btns[btnY, btnX].IsEnabled = false;
            btns[btnY, btnX].BackgroundColor = Color.Black;
        }
        public void nowaGra()
        {
            var rnd = new Random();
            foreach (Button btn in btns)
            {
                btn.BackgroundColor = Color.Turquoise;
                btn.IsEnabled = true;
                btn.Text = "";
            }
            int[] newNumbers = new int[20];

            int pom = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int num = 0; num < 10; num++)
                {
                    newNumbers[pom] = num;
                    pom++;
                }
            }
            //randomomizowanie kolejności liczb
            newNumbers = newNumbers.OrderBy(x => rnd.Next()).ToArray();

            int a = 0;
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    numbers[y, x] = newNumbers[a];
                    a++;
                }
            }
            isOneAlreadyTurned = false;
            znalezionePary = 0;
        }
        async void sprawdzCzyTeSame()
        {
            foreach(Button btn in btns)
            {
                btn.IsEnabled = false;
            }


            if (numbers[turnedCard1Loc.y, turnedCard1Loc.x] == numbers[turnedCard2Loc.y, turnedCard2Loc.x])
            {
                znalezionePary++;
                await Task.Delay(750); 
                odznaczKarte(turnedCard1Loc.y, turnedCard1Loc.x);
                odznaczKarte(turnedCard2Loc.y, turnedCard2Loc.x);
            } else
            {
                await Task.Delay(1250);
                odwroc(turnedCard1Loc.y, turnedCard1Loc.x);
                odwroc(turnedCard2Loc.y, turnedCard2Loc.x);
            }
            isOneAlreadyTurned = false;
            foreach (Button btn in btns)
            {
                if(btn.BackgroundColor != Color.Black) btn.IsEnabled = true;
            }
            if (znalezionePary == 10)
            {
                bool answer = await DisplayAlert("Question?", "Czy chcesz zagrać ponownie?", "Tak", "Nie");
                if(answer == true)
                {
                    nowaGra();
                }

            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btnHere = (Button)sender;
            int btnY = Grid.GetRow(btnHere);
            int btnX = Grid.GetColumn(btnHere);


            odwroc(btnY, btnX);

            if (isOneAlreadyTurned)
            {
                //tutaj powinienem do TurnedCard2Loc przypisywać lokalizację odsłoniętej drugiej karty
                turnedCard2Loc.y = btnY;
                turnedCard2Loc.x = btnX;
                sprawdzCzyTeSame();
                
            } else
            {
                //a tutaj do TurnedCard1Loc pierwszej
                turnedCard1Loc.y = btnY;
                turnedCard1Loc.x = btnX;
                isOneAlreadyTurned = true;
            }
        }
    }
}
