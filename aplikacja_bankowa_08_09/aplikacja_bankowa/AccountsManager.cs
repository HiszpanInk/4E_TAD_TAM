using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_bankowa
{
    internal class AccountsManager
    {
        
        private IList<Account> _accounts;
        public AccountsManager()
        {
            _accounts = new List<Account>();
        }
        public IEnumerable<Account> GetAllAccounts()
        {
            return _accounts;
        }
        private int generateId()
        {
            int id = 1;
            if (_accounts.Any())
            {
                //a to tutaj ustalany alias nazwy obiektu, wskazujemy w nawiasie że chcemy dostać id tegoż obiektu które znaleźliśmy
                //no i następnie dodajemy 1 
                id = _accounts.Max(a => a.Id) + 1;
            }
            return id;
        }
        public SavingsAccount CreateSavingsAccount(string firstName, string lastName, long pesel)
        {
            int id = generateId();
            SavingsAccount account = new SavingsAccount(id, 0.0M, firstName, lastName, pesel);
            _accounts.Add(account);
            return account;
        }
        public BillingAccount CreateBillingAccount(string firstName, string lastName, long pesel)
        {
            int id = generateId();
            BillingAccount account = new BillingAccount(id, 0.0M, firstName, lastName, pesel);
            _accounts.Add(account);
            return account;
        }

        public IEnumerable<Account> GetAllAccountsFor(long pesel)
        {
            /*List<Account> customerAccounts = new List<Account>();
            foreach (Account account in _accounts)
            {
                if (account.Pesel == pesel)
                {
                    customerAccounts.Add(account);
                }
            }
            return customerAccounts;*/
            //ta biblioteka linq bazuje na SQL, dlatego tu mamy where na przykład
            return _accounts.Where(a => a.Pesel == pesel);
        }

        public Account GetAccountByNumber(string number)
        {
            return _accounts.Single(b => b.AccountNumber == number);
        }

        public IEnumerable<string> ListOfCustomers()
        {
            return _accounts.Select(a => string.Format("Imię: {0} | Nazwisko: {1} | PESEL: {2}", a.FirstName, a.LastName, a.Pesel)).Distinct();
        }

        public IEnumerable<Account> GetAllAccountsWithSpecifiedPesel(long peselInput)
        {
            IList<Account>  foundAccounts = new List<Account>();
            foreach (Account account in _accounts)
            {
                if (account.Pesel == peselInput)
                {
                    foundAccounts.Add(account);
                }
            }

            return foundAccounts;
        }
        public void CloseMonth()
        {
            /*foreach (var account in _accounts)
            {
                if (account.TypeName() == "OSZCZĘDNOŚCIOWE")
                {
                    account.Money(0.04M);
                } 
                else
                {
                    account.Money(5.0M);
                }
                //account.EndOfMonth(0.03M, 20);   
            }*/

            foreach (SavingsAccount account in _accounts.Where(x => x is SavingsAccount))
            {
                account.AddInterest(0.04M);
            }
            foreach (BillingAccount account in _accounts.Where(x => x is BillingAccount))
            {
                account.TakeCharge(5.0M);
            }
        }
        public void AddMoney(string accountNo, decimal value)
        {
            Account account = GetAccountByNumber(accountNo);
            account.ChangeBalance(value);
        }
        public void TakeMoney(string accountNo, decimal value)
        {
            Account account = GetAccountByNumber(accountNo);
            account.ChangeBalance(-value);
        }
    }
}
