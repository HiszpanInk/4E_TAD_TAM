using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndUsers
{
    internal class Event
    {
        public int Id { get; }
        public string Name { get; }
        public Hobby Hobby { get; }
        public DateTime Timestamp { get; }
        
        public IList<int> ParticipantsIds { get; set; }

        public Event(int id, string name, Hobby hobby, DateTime timestamp)
        {
            this.Id = id;
            this.Name = name;
            this.Hobby = hobby;
            this.Timestamp = timestamp;

            this.ParticipantsIds = new List<int>();
        }
    }

}
