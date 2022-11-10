using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListApp
{
    internal class Entry
    {
        public int id { get; }
        public string name { get; set; }
        public string description { get; set; }

        public bool isFinished;

        public Entry(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.isFinished = false;
        }
    }
}
