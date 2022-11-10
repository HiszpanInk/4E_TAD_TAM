using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace imageExerciseA
{
    public partial class MainPage : ContentPage
    {
        int index;
        int imageList;
        List<List<ImageSource>> mainList;
        public MainPage()
        {
            InitializeComponent();
            mainList = new List<List<ImageSource>>();
            index = 0;
            imageList = 0;
            List<ImageSource> sourcesURI = new List<ImageSource>();
            List<ImageSource> sourcesEmbedded = new List<ImageSource>();
            List<ImageSource> sourcesLocal = new List<ImageSource>();
            
            sourcesURI.Add(ImageSource.FromUri(new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/8/8a/Tokyo_metro_map.png/1280px-Tokyo_metro_map.png")));
            sourcesURI.Add(ImageSource.FromUri(new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/Tokyo-rec.jpg/1280px-Tokyo-rec.jpg")));
            sourcesURI.Add(ImageSource.FromUri(new Uri("https://upload.wikimedia.org/wikipedia/commons/2/21/Tokyo-distances.jpg")));

            sourcesEmbedded.Add(ImageSource.FromResource("imageExerciseA.Images.ab.jpg"));
            sourcesEmbedded.Add(ImageSource.FromResource("imageExerciseA.Images.cd.jpg"));
            sourcesEmbedded.Add(ImageSource.FromResource("imageExerciseA.Images.ef.jpg"));

            sourcesLocal.Add("a.png");
            sourcesLocal.Add("b.png");
            sourcesLocal.Add("c.png");

            mainList.Add(sourcesURI);
            mainList.Add(sourcesEmbedded);
            mainList.Add(sourcesLocal);

            status.Text = String.Format("{0}/{1}", index + 1, sourcesURI.Count);
            display.Source = mainList[imageList][index];
        }

        private void Button_Clicked_Next(object sender, EventArgs e)
        {
            index++;
            status.Text = String.Format("{0}/{1}", index + 1, mainList[imageList].Count);
            display.Source = mainList[imageList][index];
        }

        private void Button_Clicked_Previous(object sender, EventArgs e)
        {
            index--;
            status.Text = String.Format("{0}/{1}", index + 1, mainList[imageList].Count);
            display.Source = mainList[imageList][index];
        }

        private void Button_Clicked_URI(object sender, EventArgs e)
        {
            imageList = 0;
            index = 0;
            status.Text = String.Format("{0}/{1}", index + 1, mainList[imageList].Count);
            display.Source = mainList[imageList][index];
        }
        private void Button_Clicked_Embedded(object sender, EventArgs e)
        {
            imageList = 1;
            index = 0;
            status.Text = String.Format("{0}/{1}", index + 1, mainList[imageList].Count);
            display.Source = mainList[imageList][index];
        }
        private void Button_Clicked_Local(object sender, EventArgs e)
        {
            imageList = 2;
            index = 0;
            status.Text = String.Format("{0}/{1}", index + 1, mainList[imageList].Count);
            display.Source = mainList[imageList][index];
        }
    }
}
