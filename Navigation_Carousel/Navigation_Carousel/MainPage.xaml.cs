using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Navigation_Carousel
{
    public partial class MainPage : CarouselPage
    {
        ObservableCollection<CarouselInfo> list;
        public MainPage()
        {
            InitializeComponent();
            list = new ObservableCollection<CarouselInfo>
            {
                new CarouselInfo{Name="William", ImageURL="https://tinyurl.com/4xzfjjkc"},
                new CarouselInfo{Name="Watson", ImageURL="https://tinyurl.com/3mhb3bzv"},
                new CarouselInfo{Name="Louis", ImageURL="https://tinyurl.com/2p8mpx2b"}
            };
            ItemsSource = list;
        }
    }
}
