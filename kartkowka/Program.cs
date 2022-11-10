using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kartkowka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<int> lista = new List<int>();
            lista.Add(4);
            lista.Add(7);
            lista.Add(10);
            lista.Add(13);
            lista.Add(16);

            foreach(int i in lista)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
