using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListApp
{
    internal class ListPositionPrinter : IPrinter
    {
        public void Print(Entry entry)
        {
            Console.WriteLine("{0}. {1}", entry.id, entry.name);
        }
    }
}
