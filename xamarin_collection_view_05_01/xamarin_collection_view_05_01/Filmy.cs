using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace xamarin_collection_view_05_01
{
    internal class Filmy
    {
        public string Nazwa { get; set; }
        public string Zdjecie { get; set; }
        public Group Kategoria { get; set; }
        public enum Group
        {
            Akcja, Horror, Komedia, Dramat
        }
    }
}
