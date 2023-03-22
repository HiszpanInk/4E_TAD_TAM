using csgoCaseOpenerXamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace csgoCaseOpenerXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryView : ContentPage
    {
        private List<History> _histories = new List<History>();
        ObservableCollection<TempHistory> temp = new ObservableCollection<TempHistory>();
        public HistoryView()
        {
            InitializeComponent();
            myCollection.ItemsSource = temp;
            GetAll();
            
            foreach (var h in _histories)
            {
                if(h.Id_Skin != 0)
                {
                    var skin = Skin.skins.Single(s => s.Id == h.Id_Skin);
                    var tempH = new TempHistory(skin.Link, skin.Name, skin.Price, h.Transcation);
                    temp.Add(tempH);
                } else
                {
                    var cas = Case.cases.Single(c => c.Id == h.Id_Case);
                    var tempH = new TempHistory(cas.Link, cas.Name, cas.Price, h.Transcation);
                    temp.Add(tempH);
                }
            }
        }
        public async void GetAll()
        {
            _histories = await App.MyDatabase.ReadHistory();
        }
        public class TempHistory
        {
            public string Picture { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public History.Typ Transaction { get; set; }

            public TempHistory(string picture, string name, decimal price, History.Typ transaction)
            {
                Picture = picture;
                Name = name;
                Price = price;
                Transaction = transaction;
            }
        }
    }
}