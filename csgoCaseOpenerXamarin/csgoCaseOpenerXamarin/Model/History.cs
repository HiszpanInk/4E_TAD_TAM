using System;
using System.Collections.Generic;
using System.Text;

namespace csgoCaseOpenerXamarin.Model
{
    public class History
    {
        public int Id { get; set; }
        public int Id_Skin { get; set; }
        public int Id_Case { get; set; }
        public decimal Price { get; set; }
        public Typ Transcation { get; set; }

        public enum Typ
        {
            Sprzedaż,
            Kupno,
            Gratis
        }
    }
}
