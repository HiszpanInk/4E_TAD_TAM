using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_bankowa
{
    internal class CustomerData
    {
        public string FirstName { get; }
        public string LastName { get; }
        public long Pesel { get; }
        public CustomerData(string firstName, string lastName, string pesel)
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = long.Parse(pesel);
        }
    }
}
