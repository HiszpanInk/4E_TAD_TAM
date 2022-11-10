using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndUsers
{
    internal class User
    {
        public int Id { get; }
        public string FirstName { get; }    
        public string LastName { get; }

        public IList<int> participantIn { get; set; }

        public User(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            this.participantIn = new List<int>();
        }
    }
}
