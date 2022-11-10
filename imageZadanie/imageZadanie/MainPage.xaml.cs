using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace imageZadanie
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

            sourcesURI.Add(new UriImageSource { 
                Uri = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/8/8a/Tokyo_metro_map.png/1280px-Tokyo_metro_map.png"),
                CachingEnabled = true,
                CacheValidity = new TimeSpan(3, 0, 0, 0)
            });
            sourcesURI.Add(new UriImageSource
            {
                Uri = new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/Tokyo-rec.jpg/1280px-Tokyo-rec.jpg"),
                CachingEnabled = true,
                CacheValidity = new TimeSpan(3, 0, 0, 0)
            });
            sourcesURI.Add(new UriImageSource
            {
                Uri = new Uri("https://upload.wikimedia.org/wikipedia/commons/2/21/Tokyo-distances.jpg"),
                CachingEnabled = true,
                CacheValidity = new TimeSpan(3, 0, 0, 0)
            });
            sourcesURI.Add(new UriImageSource
            {
                Uri = new Uri("https://technikumpolna.pl/images/gielda_banner.png"),
                CachingEnabled = false,
            });
            sourcesURI.Add(new UriImageSource
            {
                Uri = new Uri("https://previews.123rf.com/images/aquir/aquir1504/aquir150401107/39120040-example-grunge-retro-red-isolated-ribbon-stamp.jpg"),
                CachingEnabled = false,

            });
            sourcesURI.Add(new UriImageSource
            {
                Uri = new Uri("https://pbs.twimg.com/profile_images/805191808955260928/sFCDnHpP_400x400.jpg"),
                CachingEnabled = false,
            });

            sourcesEmbedded.Add(ImageSource.FromResource("imageZadanie.images.a.png"));
            sourcesEmbedded.Add(ImageSource.FromResource("imageZadanie.images.b.png"));
            sourcesEmbedded.Add(ImageSource.FromResource("imageZadanie.images.c.png"));

            sourcesLocal.Add("a1.png");
            sourcesLocal.Add("b2.png");
            sourcesLocal.Add("c3.png");
            sourcesLocal.Add("s.png");

            mainList.Add(sourcesURI);
            mainList.Add(sourcesEmbedded);
            mainList.Add(sourcesLocal);

            status.Text = String.Format("{0}/{1}", index + 1, sourcesURI.Count);
            display.Source = mainList[imageList][index];
        }

        private void Button_Clicked_Next(object sender, EventArgs e)
        {
            if(index < mainList[imageList].Count - 1)
            {
                index++;
                status.Text = String.Format("{0}/{1}", index + 1, mainList[imageList].Count);
                display.Source = mainList[imageList][index];
            }
        }

        private void Button_Clicked_Previous(object sender, EventArgs e)
        {
            if(index > 0)
            {
                index--;
                status.Text = String.Format("{0}/{1}", index + 1, mainList[imageList].Count);
                display.Source = mainList[imageList][index];
            }
            
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
