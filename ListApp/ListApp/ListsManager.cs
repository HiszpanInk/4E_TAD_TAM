using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ListApp
{
    internal class ListsManager
    {
        private EntriesManager _entriesManager;
        private ListPositionPrinter _positionPrinter = new ListPositionPrinter();
        private FullEntryPrinter _fullEntryPrinter = new FullEntryPrinter();        
        public ListsManager()
        {
            _entriesManager = new EntriesManager();
        }


        //funkcje do wyświetlania
        private void DisplayUnfinishedEvents()
        {
            IEnumerable<Entry> entries = _entriesManager.GetAllUnfinishedEntries();
            if (entries.Count() == 0)
            {
                Console.WriteLine("Brak pozycji nieukończonych");
            } else
            {
                foreach (Entry entry in entries)
                {
                    _positionPrinter.Print(entry);
                }
            }
        }
        private void DisplayFinishedEvents()
        {
            IEnumerable<Entry> entries = _entriesManager.GetAllFinishedEntries();
            if (entries.Count() == 0)
            {
                Console.WriteLine("Brak pozycji ukończonych");
            }
            else
            {
                foreach (Entry entry in entries)
                {
                    _positionPrinter.Print(entry);
                }
            }
        }

        //funkcje do wprowadzania danych
        private IList<string> GetEntryData()
        {
            string name;
            string description;
            IList<string> data = new List<string>();
            Console.Clear();
            Console.Write("Nazwa: ");
            name = Console.ReadLine();
            Console.Write("Opis: ");
            description = Console.ReadLine();
            data.Add(name);
            data.Add(description);
            return data;
        }
        private int GetEntryId(string actionCommunicate)
        {
            Console.WriteLine("");
            Console.WriteLine(actionCommunicate);
            Console.WriteLine("ID: ");
            int id = int.Parse(Console.ReadLine());
            return id;
        }

        //funkcje do tworzenia/usuwania
        private void AddEntry()
        {
            IList<string> data = GetEntryData();
            Entry newEntry = _entriesManager.CreateEntry(data[0], data[1]);
        }

        //funkcje do edycji

        //funkcje z menu
        private void PrintMainListMenu()
        {
            Console.Clear();
            DisplayUnfinishedEvents();
            Console.WriteLine("");
            Console.WriteLine("Wybierz akcję:");
            Console.WriteLine("1 - Wybierz pozycję");
            Console.WriteLine("2 - Dodaj pozycję");
            Console.WriteLine("3 - Oznacz pozycję jako ukończoną");
            Console.WriteLine("4 - Przejdź do listy ukończonych pozycji");
            Console.WriteLine("0 - Zakończ");
        }
        private void PrintFinishedListMenu()
        {
            Console.Clear();
            DisplayFinishedEvents();
            Console.WriteLine("");
            Console.WriteLine("Wybierz akcję:");
            Console.WriteLine("1 - Oznacz i przywróć pozycję jako nieukończoną");
            Console.WriteLine("2 - Wróć do głównej listy");
        }
        private void PrintEntryMenu(Entry entry)
        {
            Console.Clear();
            _fullEntryPrinter.Print(entry);
            Console.WriteLine("");
            Console.WriteLine("Wybierz akcję:");
            Console.WriteLine("1 - Edytuj pozycję");
            Console.WriteLine("2 - Oznacz pozycję jako ukończoną");
            Console.WriteLine("3 - Usuń pozycję");
            Console.WriteLine("4 - Wróć do głównej listy");
        }
        public void Run()
        {
            int selectedMenu = 0; //zależnie od tej zmiennej w pętli do będzie wyświetlane menu z aktywnymi pozycjami, nieaktywnymi pozycjami lub menu edycji pozycji
            int action = -1;
            int selectedId = -1;
            string confirment;
            do
            {
                switch(selectedMenu)
                {
                    case 0:
                        do
                        {
                            PrintMainListMenu();
                            action = SelectedAction();
                            switch (action)
                            {
                                case 1:
                                    selectedId = GetEntryId("Wybierz pozycję");
                                    selectedMenu = 2;
                                    break;
                                case 2:
                                    AddEntry();
                                    break;
                                case 3:
                                    selectedId = GetEntryId("Wybierz pozycję");
                                    _entriesManager.MarkAsFinished(selectedId);
                                    break;
                                case 4:
                                    selectedMenu = 1;
                                    break;
                            }
                        } while (ToBreak(action));
                        break;
                    case 1:
                        do
                        {
                            PrintFinishedListMenu();
                            action = SelectedAction();
                            switch (action)
                            {
                                case 1:
                                    selectedId = GetEntryId("Wybierz pozycję");
                                    _entriesManager.MarkAsUnfinished(selectedId);
                                    break;
                            }
                        } while (action != 2);
                        selectedMenu = 0;
                        break;
                    case 2:
                        do {
                            
                            PrintEntryMenu(_entriesManager.GetEntryById(selectedId));
                            action = SelectedAction();
                            switch (action)
                            {
                                case 1:
                                    IList<string> data = GetEntryData();
                                    _entriesManager.EditEntry(selectedId, data[0], data[1]);
                                    break;
                                case 2:
                                    _entriesManager.MarkAsFinished(selectedId);
                                    break;
                                case 3:
                                    Console.Write("Czy na pewno? (y/n)");
                                    confirment = Console.ReadLine();
                                    if(confirment == "y")
                                    {
                                        _entriesManager.RemoveEntry(selectedId);
                                        action = 4;
                                    }
                                    break;
                            }
                        } while (action != 4);
                        selectedMenu = 0;
                        break;
                }
                
            } while (action != 0);
        }
        
        private bool ToBreak(int action)
        {
            switch(action)
            {
                case 0:
                    return false;
                case 1:
                    return false;
                case 4:
                    return false;
                default:
                    return true;
            }
        }

        private int SelectedAction()
        {
            Console.Write("Akcja: ");
            string action = Console.ReadLine();

            if (string.IsNullOrEmpty(action))
                return -1;

            return int.Parse(action);
        }
    }
}
