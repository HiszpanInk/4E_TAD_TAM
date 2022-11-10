using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndUsers
{
    internal class ListPrinter : IPrinter
    {
        public void PrintEvent(Event Event)
        {
            Console.WriteLine("{0}. {1} ({2}) - {3}", Event.Id, Event.Name, Event.Hobby.name, Event.Timestamp.ToString());
        }
        public void PrintUser(User User)
        {
            Console.WriteLine("{0}. {1} {2}", User.Id, User.FirstName, User.LastName);
        }
        public void PrintHobby(Hobby hobby)
        {
            Console.WriteLine("{0}. {1}", hobby.id, hobby.name);
        }
    }
}
