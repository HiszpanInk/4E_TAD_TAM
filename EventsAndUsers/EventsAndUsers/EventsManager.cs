using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndUsers
{
    internal class EventsManager
    {
        private IList<Event> _events;

        public EventsManager()
        {
            _events = new List<Event>();
        }

        public void CreateEvent(string name, Hobby hobby, DateTime timestamp)
        {
            _events.Add(new Event(generateId(), name, hobby, timestamp));
        }
        public void AssignUserToEventInEvent(int userId, int eventId)
        {
            _events.Single(a => a.Id == eventId).ParticipantsIds.Add(userId);
        }
        public IList<Event> returnEventsWithIds(IList<int> InputIds)
        {
            IList<Event> eventsToReturn = new List<Event>();
            foreach (int Id in InputIds)
            {
                eventsToReturn.Add(_events.Single(a => a.Id == Id));
            }
            return eventsToReturn;
        }
        public Event returnEventById(int id)
        {
            return _events.Single(a => a.Id == id);
        }
        public IEnumerable<Event> returnEventsByHobby(int hobbyId)
        {
            return _events.Where(a => a.Hobby.id == hobbyId);
        }
        private int generateId()
        {
            int id = 1;
            if (_events.Any())
            {
                id = _events.Max(a => a.Id) + 1;
            }
            return id;
        }

        public IList<Event> returnEvents()
        {
            return _events;
        } 

    }
}
