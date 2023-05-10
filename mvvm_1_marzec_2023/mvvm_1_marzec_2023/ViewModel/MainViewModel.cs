using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using mvvm_1_marzec_2023.Model;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace mvvm_1_marzec_2023.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _entryValue;
        [ObservableProperty]
        private string _editorValue;
        [ObservableProperty]
        private ObservableCollection<Zadanie> _zadania;

        [ObservableProperty]
        private Zadanie _zad;

        public MainViewModel()
        {
            Zadania = new ObservableCollection<Zadanie>();
        }

        [RelayCommand]
        void Add()
        {
            Zadania.Add(new Zadanie(EntryValue, EditorValue));
            EntryValue = String.Empty;
            EditorValue = String.Empty;
        }

        //aby zrobić komendę asychroniczną korzystamy z Taska
        [RelayCommand]
        Task Show()
        {
            return App.Current.MainPage.DisplayAlert(Zad.Temat, Zad.Opis, "OKEJ");
        }
    }
    /*
     stare
    internal class MainViewModel : INotifyPropertyChanged
    {
        // _ oznacza prywatną zmienną
        private string _labelTxt;
        //z dużej litery jest publiczna
        public string LabelTxt
        {
            get => _labelTxt;
            set
            {
                _labelTxt = value;
                OnPropertyChanged(nameof(LabelTxt));
            }
        }


        private string _entryValue;
        public string EntryValue
        {
            get => _entryValue;
            set
            {
                _entryValue = value;
                OnPropertyChanged(nameof(EntryValue));
            }
        }

        public Command ChangeLabelCommand { get; set; }

        public MainViewModel()
        {
            ChangeLabelCommand = new Command(() =>
            {
                LabelTxt = EntryValue;
                //OnPropertyChanged(nameof(LabelValue));
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }*/
}
