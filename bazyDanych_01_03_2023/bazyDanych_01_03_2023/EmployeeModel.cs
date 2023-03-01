using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace bazyDanych_01_03_2023
{
    public class EmployeeModel
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
    }
}
