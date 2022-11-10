using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kartkowka2
{
    internal class Oceny
    {
        public IList<Ocena> oceny;
        public Oceny()
        {
            oceny = new List<Ocena>();
            oceny.Add(new Ocena(1, 3));
            oceny.Add(new Ocena(2, 1));
            oceny.Add(new Ocena(3, 4));
            oceny.Add(new Ocena(4, 3));
            oceny.Add(new Ocena(5, 4));
        }

        public IList<Ocena> getOcenyByOcena(int input)
        {
            IList<Ocena> toReturn = new List<Ocena>();
            
            
            
            foreach (Ocena ocenaTest in oceny)
            {
                if(ocenaTest.ocena == input)
                {
                    toReturn.Add(ocenaTest);
                }
            }

            return toReturn;
        }

    }
}
