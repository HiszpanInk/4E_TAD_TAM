using csgoCaseOpenerXamarin.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace csgoCaseOpenerXamarin
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath) { 
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Equipment>();
            db.CreateTableAsync<History>();
        }
        public Task<int> CreateEquipment(Equipment equipment)
        {
            return db.InsertAsync(equipment);
        }

        public Task<int> CreateHistory(History history)
        {
            return db.InsertAsync(history);
        }

        public Task<List<Equipment>> ReadEquipment()
        {
            return db.Table<Equipment>().ToListAsync();
        }

        public Task<List<History>> ReadHistory()
        {
            return db.Table<History>().ToListAsync();
        }

        public Task<int> DeleteEquipment(Equipment equipment)
        {
            return db.DeleteAsync(equipment);
        }

    }
}
