using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace csgoCaseOpenerXamarin.Model
{
    internal class Color
    {
        public static ObservableCollection<Color> colors = new ObservableCollection<Color>();
        public int Id { get; set; }
        public string Name { get; set; }
        public int Chance { get; set; }

        public Color() { }
        public Color(int id, string name, int chance)
        {
            Id = id;
            Name = name;
            Chance = chance;
        }

        public static void AddColors()
        {
            colors.Add(new Color(1, "Niebieski", 8));
            colors.Add(new Color(2, "Fioletowy", 5));
            colors.Add(new Color(3, "Różowy", 3));
            colors.Add(new Color(4, "Czerwony", 2));
            colors.Add(new Color(5, "Złoty", 1));
        }
    }
}
