using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace todoAppDatabase
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<TodoEntryModel>();
        }
        public Task<int> CreateEntry(TodoEntryModel TodoEntry)
        {
            return db.InsertAsync(TodoEntry);
        }
        public Task<List<TodoEntryModel>> ReadEntriesDate()
        {
            return db.Table<TodoEntryModel>().Where(a => a.hasDate == true).OrderBy(a => a.Date).ToListAsync();
        }
        public Task<List<TodoEntryModel>> ReadEntriesNoDate()
        {
            return db.Table<TodoEntryModel>().Where(a => a.hasDate == false).ToListAsync();
        }
        public Task<int> UpdateEntry(TodoEntryModel TodoEntry)
        {
            return db.UpdateAsync(TodoEntry);
        }
        public Task<int> DeleteEntry(TodoEntryModel TodoEntry)
        {
            return db.DeleteAsync(TodoEntry);
        }
        public Task<int> ResetTable()
        {
            return db.DropTableAsync<TodoEntryModel>();
        }
    }
}
