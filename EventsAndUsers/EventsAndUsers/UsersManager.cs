using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndUsers
{
    internal class UsersManager
    {
        private IList<User> _users;

        public UsersManager()
        {
            _users = new List<User>();
        }
        public IList<User> returnUsers()
        {
            return _users;
        }
        public IList<User> returnUsersWithIds(IList<int> InputIds)
        {
            IList<User> usersToReturn = new List<User>();
            foreach(int Id in InputIds)
            {
                usersToReturn.Add(_users.Single(a => a.Id == Id));
            }
            return usersToReturn;
        }
        public User returnUserById(int id)
        {
            return _users.Single(a => a.Id == id);
        }

        public void CreateUser(string FirstName, string LastName)
        {
            _users.Add(new User(generateId(), FirstName, LastName));
        }
        public void AssignUserToEventInUser(int userId, int eventId)
        {
            _users.Single(a => a.Id == userId).participantIn.Add(eventId);
        }
        private int generateId()
        {
            int id = 1;
            if (_users.Any())
            {
                id = _users.Max(a => a.Id) + 1;
            }
            return id;
        }
    }
}
