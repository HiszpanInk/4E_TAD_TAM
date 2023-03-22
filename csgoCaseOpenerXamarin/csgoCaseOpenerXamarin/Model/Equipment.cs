using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace csgoCaseOpenerXamarin.Model
{
    public class Equipment
    {
        [PrimaryKey,AutoIncrement]
        public int Id {  get; set; }
        public int Id_Skin {  get; set; }
    }
}
