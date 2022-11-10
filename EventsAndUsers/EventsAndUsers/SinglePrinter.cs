using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndUsers
{
    internal class SinglePrinter : IPrinter
    {
        public void PrintEvent(Event Event)
        {
            Console.WriteLine("{0} - {1} | {2}", Event.Hobby.name, Event.Name, Event.Timestamp.ToString());
        }
        public void PrintUser(User User)
        {
            Console.WriteLine("{0} {1}", User.FirstName, User.LastName);
        }
        public void PrintHobby(Hobby hobby)
        {
            Console.WriteLine("{0}", hobby.name);
        }
    }
}
