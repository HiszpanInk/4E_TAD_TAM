using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace xamarinForms_1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        
    }
}
/*
namespace xamarinForms_1
{
    public partial class MainPage : ContentPage
    {
        //Button btn;
        //Grid grid = new Grid();
        public MainPage()
        {
            InitializeComponent();
            /*
            btn = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = "Kliknij mnie"
            };
            btn.Clicked += Button_Clicked;
            grid.Children.Add(btn);
            Content = grid;
        }
        /*
        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Udało się", "Wreszcie", "OK");
        }
        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;//((Slider)sender).Value;
            sliderValue.Text = value.ToString();
            rotatingLabel.Rotation = value;
        }
    }
}
*/