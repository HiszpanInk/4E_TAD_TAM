using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listy_wpf_04_01
{
    internal class PersonData
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public PersonData(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
        }
    }
}
