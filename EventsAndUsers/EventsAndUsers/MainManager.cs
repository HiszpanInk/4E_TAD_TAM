 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace EventsAndUsers
{
    internal class MainManager
    {
        EventsManager eventsManager = new EventsManager();
        ListPrinter listPrinter = new ListPrinter();
        SinglePrinter singlePrinter = new SinglePrinter();  
        UsersManager usersManager = new UsersManager();
        HobbiesManager hobbiesManager = new HobbiesManager();
        //główna pętla
        public void Run()
        {
            int action = -1;
            do
            {
                PrintMainMenu();
                action = SelectedAction();
                switch (action)
                {
                    case 1:
                        CreateEvent();
                        break;
                    case 2:
                        CreateHobby();
                        break;
                    case 3:
                        CreateUser();
                        break;
                    case 4:
                        AssignUserToEvent();
                        break;
                    case 5:
                        ListUsersAssignedToEvent();
                        break;
                    case 6:
                        ListEventsAssignedToUser();
                        break;
                    case 7:
                        ListEventsWithHobby();
                        break;
                }
            } while (action != 0);
        }
        //rzeczy związane z menu
        public void PrintMainMenu()
        {
            Console.Clear();
            ListEvents();
            Console.WriteLine("");
            Console.WriteLine("1 - Dodaj wydarzenie");
            Console.WriteLine("2 - Dodaj hobby");
            Console.WriteLine("3 - Dodaj użytkownika");
            Console.WriteLine("4 - Przypisz użytkownika do wydarzenia");
            Console.WriteLine("5 - Wypisz użytkowników przypisanych do danego wydarzenia");
            Console.WriteLine("6 - Wypisz wydarzenia przypisane do danego użytkownika");
            Console.WriteLine("7 - Wypisz wydarzenia dla danego hobby");
            Console.WriteLine("0 - Zakończ");
        }
        private int SelectedAction()
        {
            Console.Write("Akcja: ");
            string action = Console.ReadLine();

            if (string.IsNullOrEmpty(action))
                return -1;

            return int.Parse(action);
        }

        //wypisywanie
        private void ListEvents()
        {
            IList <Event> events = eventsManager.returnEvents();
            foreach(Event e in events)
            {
                listPrinter.PrintEvent(e);
            }
        }
        private void ListHobbies()
        {
            IList<Hobby> hobbies = hobbiesManager.returnHobbies();
            foreach (Hobby h in hobbies)
            {
                listPrinter.PrintHobby(h);
            }
        }
        private void ListUsers()
        {
            IList<User> users = usersManager.returnUsers();
            foreach (User u in users)
            {
                listPrinter.PrintUser(u);
            }
        }
        private void ListUsersAssignedToEvent()
        {
            string EventId;
            Console.WriteLine("");
            Console.Write("ID wydarzenia: ");
            EventId = Console.ReadLine();
            Event selectedEvent = eventsManager.returnEventById(int.Parse(EventId));
            IList <User> EventUsersList = usersManager.returnUsersWithIds(selectedEvent.ParticipantsIds);

            singlePrinter.PrintEvent(selectedEvent);
            Console.WriteLine("Uczestnicy:");
            foreach (User u in EventUsersList)
            {
                singlePrinter.PrintUser(u);
            }
            Console.ReadKey();
        }
        private void ListEventsAssignedToUser()
        {
            string UserId;
            Console.WriteLine("");
            Console.Write("ID użytkownika: ");
            UserId = Console.ReadLine();
            User selectedUser = usersManager.returnUserById(int.Parse(UserId));
            IList<Event> UserEventsList = eventsManager.returnEventsWithIds(selectedUser.participantIn);

            singlePrinter.PrintUser(selectedUser);
            Console.WriteLine("Wydarzenia w których bierze udział:");
            foreach (Event e in UserEventsList)
            {
                singlePrinter.PrintEvent(e);
            }
            Console.ReadKey();
        }
        private void ListEventsWithHobby()
        {
            Console.Clear();
            string HobbyId;
            Console.WriteLine("");
            ListHobbies();
            Console.WriteLine("");
            Console.Write("ID hobby: ");
            HobbyId = Console.ReadLine();
            IEnumerable<Event> selectedEvents = eventsManager.returnEventsByHobby(int.Parse(HobbyId));
            foreach (Event e in selectedEvents)
            {
                singlePrinter.PrintEvent(e);
            }
            Console.ReadKey();
        }
        //dodawanie
        private void CreateEvent()
        {
            string Name, Hobby, date, time;
            DateTime dateTime = new DateTime();
            Console.WriteLine("Podaj dane wydarzenia: ");
            Console.Write("Nazwę: ");
            Name = Console.ReadLine();
            Console.WriteLine("");

            ListHobbies();

            Console.Write("ID hobby: ");
            Hobby = Console.ReadLine();
            Console.Write("Datę (w formacie DD-MM-YYYY): ");
            date = Console.ReadLine();
            Console.Write("Godzinę (w formacie HH:MM): ");
            time = Console.ReadLine();
            dateTime = DateTime.Parse($"{date} {time}:00");

            eventsManager.CreateEvent(Name, hobbiesManager.returnHobbyById(int.Parse(Hobby)), dateTime);
        } 
        private void CreateUser()
        {
            string FirstName, LastName;
            Console.WriteLine("Podaj dane użytkownika: ");
            Console.Write("Imię: ");
            FirstName = Console.ReadLine();
            Console.Write("Nazwisko: ");
            LastName = Console.ReadLine();

            usersManager.CreateUser(FirstName, LastName);
        }
        private void CreateHobby()
        {
            string Name;
            Console.WriteLine("Podaj dane hobby: ");
            Console.Write("Nazwa: ");
            Name = Console.ReadLine();

            hobbiesManager.CreateHobby(Name);
        }

        //przypisywanie
        private void AssignUserToEvent()
        {
            string userId, stringEventId;
            Console.WriteLine("");
            Console.Write("ID wydarzenia: ");
            stringEventId = Console.ReadLine();
            Console.WriteLine("");
            ListUsers();
            Console.WriteLine("");
            Console.Write("ID użytkownika: ");
            userId = Console.ReadLine();
            Console.WriteLine("");

            eventsManager.AssignUserToEventInEvent(int.Parse(userId), int.Parse(stringEventId));
            usersManager.AssignUserToEventInUser(int.Parse(userId), int.Parse(stringEventId));
        }


    }
}
