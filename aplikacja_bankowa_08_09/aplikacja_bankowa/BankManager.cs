using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_bankowa
{
    internal class BankManager
    {

        private AccountsManager _accountsManager;
        private IPrinter _printer;
        
        public BankManager()
        {
            _accountsManager = new AccountsManager();
            _printer = new Printer();
        }

        private void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Wybierz akcję:");
            Console.WriteLine("1 - Lista kont klienta");
            Console.WriteLine("2 - Dodaj konto rozliczeniowe");
            Console.WriteLine("3 - Dodaj konto oszczęnościowe");
            Console.WriteLine("4 - Wpłać pieniądze na konto");
            Console.WriteLine("5 - Wypłać pieniądze z konta");
            Console.WriteLine("6 - Lista klientów");
            Console.WriteLine("7 - Wszystkie konta");
            Console.WriteLine("8 - Zakończ miesiąc");
            Console.WriteLine("0 - Zakończ");
        }
        public void Run()
        {
            int action;
            do
            {
                PrintMainMenu();
                action = SelectedAction();
                switch(action)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Wybrano listę kont użytkownika");
                        UserAccountsList();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Wybrano otwarcie konta rozliczeniowego");
                        CreateBillingAccount();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Wybrano otwarcie konta oszczędnościowego");
                        CreateSavingsAccount();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Wybrano wpłatę pieniędzy na konto");
                        AddMoney();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Wybrano wypłatę pieniędzy z konta");
                        TakeMoney();
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Wybrano listę wszystkich klientów");
                        DisplayCustomersList();
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Wybrano listę wszystkich kont");
                        DisplayAllAccounts();
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("Wybrano zakończenie miesiąca");
                        CloseMonth();
                        Console.ReadKey();
                        break;
                }
            } while (action != 0);
        }
        private int SelectedAction()
        {
            Console.Write("Akcja: ");
            string action = Console.ReadLine();
            
            if (string.IsNullOrEmpty(action))
                return -1;

            return int.Parse(action);
        }

        //private IEnumerable<Account> UserAccountsList()
       void UserAccountsList()
        {
            Console.Write("PESEL: ");
            string pesel = Console.ReadLine();
            //long pesel = long.Parse(Console.ReadLine());
            foreach (Account account in _accountsManager.GetAllAccountsFor(long.Parse(pesel)))
            {
                _printer.Print(account);
            }
        }
        private CustomerData ReadCustomerData()
        {
            string firstName;
            string lastName;
            string pesel;
            Console.Write("Podaj dane klienta: ");
            Console.Write("Imię: ");
            firstName = Console.ReadLine();
            Console.Write("Nazwisko: ");
            lastName = Console.ReadLine();
            Console.Write("PESEL: ");
            pesel = Console.ReadLine();

            return new CustomerData(firstName, lastName, pesel);
        }
        private void CreateBillingAccount()
        {
            CustomerData data = ReadCustomerData();
            Account billing = _accountsManager.CreateBillingAccount(data.FirstName, data.LastName, data.Pesel);
            Console.WriteLine("Utworzono konto: ");
            _printer.Print(billing);
        }
        private void CreateSavingsAccount()
        {
            CustomerData data = ReadCustomerData();
            Account savings = _accountsManager.CreateSavingsAccount(data.FirstName, data.LastName, data.Pesel);
            Console.WriteLine("Utworzono konto: ");
            _printer.Print(savings);
        }
        private AccountCustomerData ReadAccountCustomerData()
        {
            string accountNumber;
            string balance;

            Console.Write("Podaj dane klienta: ");
            Console.Write("Numer konta: ");
            accountNumber = Console.ReadLine();
            Console.Write("Wielkość wpłaty/wypłaty: ");      
            balance = Console.ReadLine();

            return new AccountCustomerData(accountNumber, balance);
        }
        private void AddMoney()
        {
            AccountCustomerData data = ReadAccountCustomerData(); 
            _accountsManager.AddMoney(data.AccountNumber, data.Balance);
            Account account = _accountsManager.GetAccountByNumber(data.AccountNumber);
            _printer.Print(account);
        }
        private void TakeMoney()
        {
            AccountCustomerData data = ReadAccountCustomerData();
            _accountsManager.TakeMoney(data.AccountNumber, data.Balance);
            Account account = _accountsManager.GetAccountByNumber(data.AccountNumber);
            _printer.Print(account);
        }
        private void DisplayCustomersList()
        {
            IEnumerable<string> list = _accountsManager.ListOfCustomers();
            foreach(string customer in list)
            {
                Console.WriteLine(customer);
            }
        }
        private void DisplayAllAccounts()
        {
            IEnumerable<Account> list = _accountsManager.GetAllAccounts();
            foreach (Account account in list)
            {
                _printer.Print(account);
            }
        }
        private void CloseMonth()
        {
            _accountsManager.CloseMonth();
            Console.WriteLine("Miesiąc zamknięty");
        }
    }
}

