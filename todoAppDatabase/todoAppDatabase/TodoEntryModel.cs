using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace todoAppDatabase
{
    public class TodoEntryModel
    {
        

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string EntryContent { get; set; }
        public bool hasDate { get; set; }
        public DateTime Date { get; set; }
        public int Priority { get; set; }
        //public EntryPriority Priority { get; set; }
        public enum EntryPriority : int
        {
            Low = 0,
            Medium = 1,
            High = 2
        }
       
    }
}
