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
        string[] cytaty = new string[5];
        Color[] colors = new Color[4];
        Random rand = new Random();




        public MainPage()
        {
            InitializeComponent();
            cytaty[0] = "a";
            cytaty[1] = "Lorem ipsum dolor sit amet";
            cytaty[2] = "Kłamaliśmy rano, w nocy i wieczorem";
            cytaty[3] = "Zażółć gęślą jaźń";
            cytaty[4] = "c";

            colors[0] = Xamarin.Forms.Color.Red;
            colors[1] = Xamarin.Forms.Color.Green;
            colors[2] = Xamarin.Forms.Color.Blue;
            colors[3] = Xamarin.Forms.Color.Black;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int nfdsa = rand.Next(0, 4);
            mainLabel.Text = cytaty[nfdsa];
        }

        private void red(object sender, EventArgs e)
        {
            mainLabel.TextColor = Xamarin.Forms.Color.Red;
        }
        private void green(object sender, EventArgs e)
        {
            mainLabel.TextColor = Xamarin.Forms.Color.Green;
        }
        private void blue(object sender, EventArgs e)
        {
            mainLabel.TextColor = Xamarin.Forms.Color.Blue;
        }
        private void black(object sender, EventArgs e)
        {
            mainLabel.TextColor = Xamarin.Forms.Color.Black;
        }
        /*private void colourChange(object sender, EventArgs e)
        {
            mainLabel.TextColor = colors[sender.];
        }*/
    }
}
