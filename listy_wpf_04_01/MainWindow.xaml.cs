using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace listy_wpf_04_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<PersonData> ListOfNames = new ObservableCollection<PersonData>();
        public MainWindow()
        {
            InitializeComponent();
            ListOfNames.Add(new PersonData("Lorem", 20, "lorem@lorem.pl"));
            ListOfNames.Add(new PersonData("Ipsum", 20, "ipsum@ipsum.pl"));
            ListOfNames.Add(new PersonData("Dolor", 20, "dolor@dolor.pl"));
            ListOfNames.Add(new PersonData("Sit", 20, "sit@sit.pl"));
            ListOfNames.Add(new PersonData("Amet", 20, "amet@amet.pl"));

            dataGridOfPeople.ItemsSource = ListOfNames;
            //ListaImion.ItemsSource = ListOfNames;
        }
        /*
        private void ListBox_Selected(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(ListaImion.SelectedIndex.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListOfNames.Add(new PersonData(NameToAdd.Text, int.Parse(AgeToAdd.Text), EmailToAdd.Text));
            NameToAdd.Text = null;
            AgeToAdd.Text = null;
            EmailToAdd.Text = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //ListaImion.Items.Remove(ListaImion.Items.GetItemAt(ListaImion.SelectedIndex));
            PersonData selected = (PersonData)ListaImion.SelectedItem;
            if(selected != null)
            {
                ListOfNames.Remove(selected);
            }
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader header = (sender as GridViewColumnHeader);
            string columnNameToSort = header.Content.ToString();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListaImion.ItemsSource);
            ListSortDirection howToSort = ListSortDirection.Ascending;

            if(view.SortDescriptions.Any())
            {
                SortDescription item = view.SortDescriptions.ElementAt(0);
                if(columnNameToSort == item.PropertyName.ToString())
                {
                    if(item.Direction == ListSortDirection.Ascending)
                    {
                        howToSort = ListSortDirection.Descending;
                    } else
                    {
                        howToSort = ListSortDirection.Ascending;
                    }
                }
            }
            
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(columnNameToSort, howToSort));
        }*/
    }
}
