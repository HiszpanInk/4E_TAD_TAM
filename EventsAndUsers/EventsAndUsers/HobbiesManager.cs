using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndUsers
{
    internal class HobbiesManager
    {
        private IList<Hobby> _hobbies;
        public HobbiesManager()
        {
            _hobbies = new List<Hobby>();
        }
        public void CreateHobby(string newHobbyName)
        {
            _hobbies.Add(new Hobby(generateId(), newHobbyName));
        }
        public Hobby returnHobbyById(int id)
        {
            return _hobbies.Single(a => a.id == id);
        }
        public IList<Hobby> returnHobbies()
        {
            return _hobbies;
        }
        private int generateId()
        {
            int id = 1;
            if (_hobbies.Any())
            {
                id = _hobbies.Max(a => a.id) + 1;
            }
            return id;
        }
    }
}
    