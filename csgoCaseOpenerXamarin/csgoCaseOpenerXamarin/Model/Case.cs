using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace csgoCaseOpenerXamarin.Model
{
    public class Case
    {
        public static ObservableCollection<Case> cases = new ObservableCollection<Case>();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public decimal Price { get; set; }

        public Case() { }
        public Case(int id, string name, string link, decimal price)
        {
            Id = id;
            Name = name;
            Link = link;
            Price = price;
        }

        public static void AddCase()
        {
            cases.Add(new Case(1, "Operation Broken Fang Case", "https://technikumpolna.pl/csgo4e1/skrzynki/OperationBrokenFangCase.png", 2.20M));
            cases.Add(new Case(2, "Chroma 2 Case", "https://technikumpolna.pl/csgo4e1/skrzynki/chroma2case.png", 1.22M));
            cases.Add(new Case(3, "Revolution Case", "https://technikumpolna.pl/csgo4e1/skrzynki/revolutionCase.png", 2.31M));
            cases.Add(new Case(4, "Shattered Web Case", "https://technikumpolna.pl/csgo4e1/skrzynki/ShatteredWebCase.png", 1.56M));
            cases.Add(new Case(5, "Recoil Case", "https://technikumpolna.pl/csgo4e1/skrzynki/RecoilCase.png", 0.69M));
            cases.Add(new Case(6, "Operation Breakout Weapon Case", "https://technikumpolna.pl/csgo4e1/skrzynki/OperationBreakoutWeaponCase.png", 4.62M));
            cases.Add(new Case(7, "Shadow Case", "https://technikumpolna.pl/csgo4e1/skrzynki/ShadowCase.png", 0.44M));
            cases.Add(new Case(8, "Operation Bravo Case", "https://technikumpolna.pl/csgo4e1/skrzynki/OperationBravoCase.png", 46.30M));
            cases.Add(new Case(9, "Operation Hydra Case", "https://technikumpolna.pl/csgo4e1/skrzynki/OperationHydraCase.png", 15.53M));
            cases.Add(new Case(10, "Huntsman Weapon Case", "https://technikumpolna.pl/csgo4e1/skrzynki/HuntsmanWeaponCase.png", 6.87M));
        }
    }
}
