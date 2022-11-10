using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndUsers
{
    internal interface IPrinter
    {
        void PrintEvent(Event Event);
        void PrintUser(User User);
        void PrintHobby(Hobby hobby);
    }
}
