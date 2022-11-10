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
        //                            [Y, X]
        Button[,] btns;// = new Button[5, 4];
        int[,] numbers;// = new int[5, 4];
        int Y_num;
        int X_num;
        int allFieldsCount;
        int odwrocenieCzas;

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
        bool toCheckSingle;

        double deviceHeight;
        double availableDeviceHeight;
        double deviceWidth;
        double availableDeviceWidth;


        public MainPage()
        {
            InitializeComponent();

            startStart();
            /*
            btns = new Button[Y_num, X_num];
            numbers = new int[Y_num, X_num];
            var rnd = new Random();
            //tworzenie tablicy z liczbami
            int[] tempNumbers = new int[allFieldsCount];

            int pom = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int num = 0; num < allFieldsCount / 2; num++)
                {
                    tempNumbers[pom] = num;
                    pom++;
                }
            }
            //randomomizowanie kolejności liczb
            tempNumbers = tempNumbers.OrderBy(x => rnd.Next()).ToArray();
            //tworzenie przycisków i oddawanie ich na planszę oraz tworzenie dwuwymiarowej tablicy z liczbami
            int a = 0;
            for (int y = 0; y < Y_num; y++)
            {
                for (int x = 0; x < X_num; x++)
                {
                    numbers[y, x] = tempNumbers[a];
                    a++;
                    btns[y, x] = new Button();
                    btns[y, x].Clicked += Button_Clicked;
                    btns[y, x].BackgroundColor = Color.Turquoise;

                    plansza.Children.Add(btns[y, x], x, y);

                }
            }*/
        
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
        /*void wielkoscPlanszy()
        {
            do
            {

            } while ((Y_num * X_num) % 2 == 1);
            allFieldsCount = X_num * Y_num;
        }*/
        
        public async Task wielkoscPlanszy()
        {
            do
            {
                X_num = int.Parse(await DisplayPromptAsync("Question 1", "Podaj pożądaną ilość kolumn:"));
                Y_num = int.Parse(await DisplayPromptAsync("Question 2", "Podaj pożądaną ilość wierszy:"));
                if ((Y_num * X_num) % 2 == 1)
                {
                    await DisplayAlert("Alert", "Łączna liczba pól musi być parzysta!", "OK");
                }
            } while((Y_num * X_num) % 2 == 1);
            odwrocenieCzas = int.Parse(await DisplayPromptAsync("Question 3", "Podaj w sekundu ilość czasu na odwrócenie: ")) * 1000;
            allFieldsCount = X_num * Y_num;
            plansza.IsVisible = true;
        }
        async void startStart()
        {
            await wielkoscPlanszy();
            deviceHeight = Application.Current.MainPage.Height;
            availableDeviceHeight = deviceHeight - 400;
            deviceWidth = Application.Current.MainPage.Width;

            toCheckSingle = false;
            isOneAlreadyTurned = false;
            znalezionePary = 0;

            //plansza.Margin = string.Format("{0}, 0, 0, 0", deviceHeight / 10);

            btns = new Button[Y_num, X_num];
            numbers = new int[Y_num, X_num];
            var rnd = new Random();
            //tworzenie tablicy z liczbami
            int[] tempNumbers = new int[allFieldsCount];

            int pom = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int num = 0; num < allFieldsCount / 2; num++)
                {
                    tempNumbers[pom] = num;
                    pom++;
                }
            }
            //randomomizowanie kolejności liczb
            tempNumbers = tempNumbers.OrderBy(x => rnd.Next()).ToArray();
            //tworzenie przycisków i oddawanie ich na planszę oraz tworzenie dwuwymiarowej tablicy z liczbami
            int a = 0;
            for (int y = 0; y < Y_num; y++)
            {
                //plansza.Children.Add(Grid.RowDefinitionsProperty())
                for (int x = 0; x < X_num; x++)
                {
                    numbers[y, x] = tempNumbers[a];
                    a++;
                    btns[y, x] = new Button();
                    btns[y, x].Clicked += Button_Clicked;
                    btns[y, x].BackgroundColor = Color.Turquoise;
                    
                    btns[y, x].WidthRequest = Math.Floor(deviceWidth / X_num);
                    btns[y, x].HeightRequest = btns[y, x].WidthRequest;
                    //btns[y, x].FontSize = btns[y, x].WidthRequest - 4;

                    plansza.Children.Add(btns[y, x], x, y);

                }
            }
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
        /*public void nowaGra()
        {
            var rnd = new Random();
            foreach (Button btn in btns)
            {
                btn.BackgroundColor = Color.Turquoise;
                btn.IsEnabled = true;
                btn.Text = "";
            }
            int[] newNumbers = new int[allFieldsCount];

            int pom = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int num = 0; num < allFieldsCount / 2; num++)
                {
                    newNumbers[pom] = num;
                    pom++;
                }
            }
            //randomomizowanie kolejności liczb
            newNumbers = newNumbers.OrderBy(x => rnd.Next()).ToArray();

            int a = 0;
            for (int y = 0; y < Y_num; y++)
            {
                for (int x = 0; x < X_num; x++)
                {
                    numbers[y, x] = newNumbers[a];
                    a++;
                }
            }
            isOneAlreadyTurned = false;
            znalezionePary = 0;
        }*/
        async void sprawdzCzyTeSame()
        {
            toCheckSingle = false;
            if(!((turnedCard1Loc.y == turnedCard2Loc.y) && (turnedCard1Loc.x == turnedCard2Loc.x)))
            {
                foreach (Button btn in btns)
                {
                    btn.IsEnabled = false;
                }


                if (numbers[turnedCard1Loc.y, turnedCard1Loc.x] == numbers[turnedCard2Loc.y, turnedCard2Loc.x])
                {
                    znalezionePary++;
                    await Task.Delay(750);
                    odznaczKarte(turnedCard1Loc.y, turnedCard1Loc.x);
                    odznaczKarte(turnedCard2Loc.y, turnedCard2Loc.x);
                }
                else
                {
                    await Task.Delay(1250);
                    odwroc(turnedCard1Loc.y, turnedCard1Loc.x);
                    odwroc(turnedCard2Loc.y, turnedCard2Loc.x);
                }
                isOneAlreadyTurned = false;
                
                if (znalezionePary == (allFieldsCount / 2))
                {
                    bool answer = await DisplayAlert("Question?", "Czy chcesz zagrać ponownie?", "Tak", "Nie");
                    if (answer == true)
                    {
                        startStart();
                    }

                }
            }
            await Task.Delay(250);
            foreach (Button btn in btns)
            {
                if (btn.BackgroundColor != Color.Black) btn.IsEnabled = true;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            toCheckSingle = false;
            Button btnHere = (Button)sender;
            int btnY = Grid.GetRow(btnHere);
            int btnX = Grid.GetColumn(btnHere);
            odwroc(btnY, btnX);
            if (isOneAlreadyTurned)
            {
                turnedCard2Loc.y = btnY;
                turnedCard2Loc.x = btnX;
                toCheckSingle = false;
                sprawdzCzyTeSame();
                
            } else
            {
                turnedCard1Loc.y = btnY;
                turnedCard1Loc.x = btnX;
                isOneAlreadyTurned = true;
                toCheckSingle = true;
                btns[turnedCard1Loc.y, turnedCard1Loc.x].IsEnabled = false;
                turnIfTime();
            }
        }
        async void turnIfTime()
        {
            await Task.Delay(odwrocenieCzas);
            if (toCheckSingle)
            {
                int btnY = turnedCard1Loc.y;
                int btnX = turnedCard1Loc.x;

                btns[btnY, btnX].BackgroundColor = Color.Turquoise;
                btns[btnY, btnX].IsEnabled = true;
                btns[btnY, btnX].Text = "";

                isOneAlreadyTurned =false;

                btns[turnedCard1Loc.y, turnedCard1Loc.x].IsEnabled = true;
            }
        }

        /*private void Button_Clicked_Start(object sender, EventArgs e)
        {

        }*/
    }
}
