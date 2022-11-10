using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_bankowa
{
    //IPrinter to interfejs, jest on tutaj przypisany do klasy Printer
    internal class Printer : IPrinter
    {
        public void Print(Account account)
        {
            Console.WriteLine("Dane konta: ");
            Console.WriteLine("Numer konta: {0}", account.AccountNumber);
            Console.WriteLine("Rodzaj konta: {0}", account.TypeName());
            Console.WriteLine("Środki na koncie: {0} zł", account.Balance);
            Console.WriteLine("Imię i nazwisko właściciela: {0}", account.GetFullName());
            Console.WriteLine("PESEL właściciela: {0}", account.Pesel);
            Console.WriteLine("");
        }
    }
}
