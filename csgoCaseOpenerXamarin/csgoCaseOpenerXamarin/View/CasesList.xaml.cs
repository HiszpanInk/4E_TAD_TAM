using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace csgoCaseOpenerXamarin.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CasesList : ContentPage
	{
		public CasesList ()
		{
			InitializeComponent ();
			casesCollection.ItemsSource = Model.Case.cases;
		}

        private async void CaseTapped(object sender, EventArgs e)
        {
			var item = (TappedEventArgs)e;
			var selectedCase = item.Parameter as Model.Case;

			await Navigation.PushAsync(new CaseSkins(selectedCase));
        }
    }
}