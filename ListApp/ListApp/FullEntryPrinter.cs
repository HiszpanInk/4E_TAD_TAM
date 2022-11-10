using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListApp
{
    internal class FullEntryPrinter : IPrinter
    {
        public void Print(Entry entry)
        {
            Console.WriteLine("ID pozycji: {0}", entry.id);
            Console.WriteLine("{0} - {1}", entry.name, entry.description);
        }
    }
}
