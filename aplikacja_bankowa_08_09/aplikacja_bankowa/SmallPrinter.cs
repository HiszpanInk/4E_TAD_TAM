using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_bankowa
{
    internal class SmallPrinter : IPrinter
    {
        public void Print(Account account)
        {
            Console.WriteLine("Numer konta: {0}", account.AccountNumber);
            Console.WriteLine("Imię i nazwisko właściciela: {0}", account.GetFullName());
            Console.WriteLine("");
        }
    }
}
