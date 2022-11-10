using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListApp
{
    internal class EntriesManager
    {
        private IList<Entry> _entries;
        public int EntriesNum;
        public EntriesManager()
        {
            _entries = new List<Entry>();
            EntriesNum = 0;
        }
        private int generateId()
        {
            int id = 1;
            if (_entries.Any())
            {
                id = _entries.Max(a => a.id) + 1;
            }
            EntriesNum++;
            return id;
        }
        public Entry GetEntryById(int id)
        {
            return _entries.Single(a => a.id == id);
        }
        public Entry CreateEntry(string name, string description)
        {
            Entry newEntry = new Entry(generateId(), name, description);
            _entries.Add(newEntry);
            EntriesNum++;
            return newEntry;
        }
        public void EditEntry(int id, string name, string description)
        {
            _entries.Single(a => a.id == id).name = name;
            _entries.Single(a => a.id == id).description = description;
        }
        public void RemoveEntry(int id)
        {
            _entries.Remove(GetEntryById(id));
            EntriesNum--;
        }
        public IEnumerable<Entry> GetAllUnfinishedEntries()
        {
            return _entries.Where(e => e.isFinished == false);
        }
        public IEnumerable<Entry> GetAllFinishedEntries()
        {
            return _entries.Where(e => e.isFinished == true);
        }

        public void MarkAsFinished(int id)
        {
            _entries.Single(a => a.id == id).isFinished = true;
        }
        public void MarkAsUnfinished(int id)
        {
            _entries.Single(a => a.id == id).isFinished = false;
        }
    }
}
