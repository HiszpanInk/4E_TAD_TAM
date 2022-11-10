using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kartkowka2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Oceny oceny1 = new Oceny();
            IList<Ocena> ocenyLista = oceny1.getOcenyByOcena(4);
            foreach(Ocena ocena in ocenyLista)
            {
                Console.WriteLine("ID: {0}, Ocena: {1} ", ocena.id, ocena.ocena);
            }
            Console.ReadKey();

            
        }
    }
}
