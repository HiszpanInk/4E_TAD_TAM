using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace bazyDanych_01_03_2023
{
    public partial class MainPage : ContentPage
    {
        EmployeeModel tempEmployee = null;
        //ObservableCollection<EmployeeModel> employees = new ObservableCollection<EmployeeModel>();
        public MainPage()
        {
            InitializeComponent();
            //employees.Add(new EmployeeModel { Id = 1, Name = "Jan Kowalski", Adress = "PL" });
            //employees.Add(new EmployeeModel { Id = 2, Name = "Adam Nowak", Adress = "PL" });
            //myCollectionView.ItemsSource = employees;
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                myCollectionView.ItemsSource = await App.MyDatabase.ReadEmployees();
            }
            catch { }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(nameEntry.Text) || string.IsNullOrWhiteSpace(adressEntry.Text))
            {
                await DisplayAlert("Błąd", "Błędnie wpisane dane: puste lub spacje", "OK");
            } else if(tempEmployee == null)
            {
                AddNewEmployee();
            } else
            {
                EditEmployee(tempEmployee);
            }
        }

        private async void EditEmployee(EmployeeModel employee)
        {
            employee.Name = nameEntry.Text;
            employee.Adress = adressEntry.Text;
            await App.MyDatabase.UpdateEmployee(employee);
            Refresh();
            
        }

        private async void Refresh()
        {
            myCollectionView.ItemsSource = null;
            
            //var lista = await App.MyDatabase.ReadEmployees();
            //int i = 1;
            //foreach ( var item in lista ) { 
           //     item.Id = i++;
            //}
            //myCollectionView.ItemsSource = lista;
            
            myCollectionView.ItemsSource = await App.MyDatabase.ReadEmployees();
            nameEntry.Text = string.Empty;
            adressEntry.Text = string.Empty;
            btn.Text = "SAVE";
            tempEmployee = null;
        }

        private async void AddNewEmployee()
        {
            await App.MyDatabase.CreateEmployee(new EmployeeModel { Name = nameEntry.Text, Adress = adressEntry.Text });
            Refresh();
        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var emp = item.CommandParameter as EmployeeModel;
            var result = await DisplayAlert("USUNIĘCIE", $"Czy na pewno chcesz usunąć {emp.Name}?", "Tak", "Nie");
            if (result)
            {
                await App.MyDatabase.DeleteEmployee(emp);
                Refresh();
            }
        }

        private void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            tempEmployee = item.CommandParameter as EmployeeModel;
            nameEntry.Text = tempEmployee.Name;
            adressEntry.Text = tempEmployee.Adress;
            btn.Text = "EDIT";
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            myCollectionView.ItemsSource = await App.MyDatabase.Search(e.NewTextValue.ToUpper());
        }
    }
}
