using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace projetu
namespace aplikacja_bankowa
{
    internal class Program
    {
        static void Main(string[] args)
        {
           /* IPrinter printer = new Printer();
            IPrinter smallPrinter = new SmallPrinter();

            AccountsManager manager = new AccountsManager();
            manager.CreateSavingsAccount("Adam", "Kowalski", 86121302331);
            manager.CreateBillingAccount("Adam", "Kowalski", 86121302331);
            manager.CreateBillingAccount("Leszek", "Adamczewski", 12345678901);

            

            foreach (Account account in manager.GetAllAccounts())
            {
                smallPrinter.Print(account);
            }
            //                        ten nawias oznacza że to będzie typ danych w liście
            IList<Account> accounts = (IList<Account>)manager.GetAllAccounts();

            printer.Print(manager.GetAccountByNumber("940000000003"));

            //foreach (Account account in manager.GetAllAccountsFor(86121302331))
            //{
            //    printer.Print(account);
            //}
            foreach(string user in manager.ListOfCustomers())
            {
                Console.WriteLine(user);
            }

            /*
             * jakieś różne notatki
            Console.WriteLine("Autor: Wojciech Sz");
            //var zmienna = "dsa"; //var w C# działa jak zmienne w Go, typ zmiennej jest przypisywany na podstawie tego jaka wartość jest do niej przypisana (i typ jest ustalany dopiero jak jest deklarowana jej wartość)
            int wersja = 1;
            Console.WriteLine("wersja {0}", wersja); //wsadzanie zmiennej do stringa
            Console.WriteLine("");

            SavingsAccount savingsAccount = new SavingsAccount("940000000001", 0.0M, "Adam", "Kowalski", 86121302331); //to M na końcu oznacza do której liczby po przecinku zaokrąglamy oraz miliony które mamy na koncie
            printer.Print(savingsAccount);
            BillingAccount billingAccount = new BillingAccount("940000000002", 0.0M, "Adam", "Kowalski", 86121302331);
            smallPrinter.Print(billingAccount);

            IList<Account> accounts = new List<Account>();
            accounts.Add(new SavingsAccount(1, 0.0M,, 86121302331));
            accounts.Add(new BillingAccount(2, 0.0M, "Adam", "Kowalski", 86121302331));
            */

            // IPrinter smallPrinter = new SmallPrinter();

            //printer.Print(accounts[0]);
            //smallPrinter.Print(accounts[1]);
            BankManager bank = new BankManager();    
            bank.Run();



            //Console.ReadKey(); //czekanie na klawisz jakiś, zapobiega to tutaj wyłączeniu od razu po wykonaniu i niemożności zobaczenia rezultatu
        }
    }
}
