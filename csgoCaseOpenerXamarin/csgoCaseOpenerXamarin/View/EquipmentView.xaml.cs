using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csgoCaseOpenerXamarin.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static csgoCaseOpenerXamarin.HistoryView;

namespace csgoCaseOpenerXamarin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EquipmentView : ContentPage
    {
        private List<Equipment> _equipments = new List<Equipment>();
        //private ObservableCollection<TempEquipment> _equipmentsDisplay = new ObservableCollection<TempEquipment>();

        private List<Skin> _skins;
        public  EquipmentView()
        {
            GetAll();
            _skins = new List<Skin>(Skin.skins);
            
            InitializeComponent();
            getList();


        }
        public void getList()
        {
            var query = from Equipment in _equipments
                        join Skin in Skin.skins
                            on Equipment.Id_Skin equals Skin.Id
                        select new
                        {
                            Skin.Id,
                            Skin.Link,
                            Skin.Name,
                            Skin.Price,
                        };          
            myCollection.ItemsSource = query.ToList();

        }
        public async void GetAll()
        {
            _equipments = await App.MyDatabase.ReadEquipment();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var item = sender as Button;
            int id = (int)item.CommandParameter;

            var eq = _equipments.First(ee => ee.Id_Skin == id);
            await App.MyDatabase.DeleteEquipment(eq);
            myCollection.ItemsSource = null;
            getList();
            
            var skin = Skin.skins.Single(s => s.Id == id);
            Bankroll.UserBankroll += skin.Price;
            
            History h = new History();
            h.Id_Case = 0;
            h.Id_Skin = id;
            h.Price = skin.Price;
            h.Transcation = History.Typ.Sprzedaż;
            await App.MyDatabase.CreateHistory(h);
        }
       
    }
}