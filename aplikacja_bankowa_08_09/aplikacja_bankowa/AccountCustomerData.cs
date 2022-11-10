using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_bankowa
{
    internal class AccountCustomerData
    {
        public string AccountNumber { get; }
        public decimal Balance { get; }
        public AccountCustomerData(string accountNumber, string balance)
        {
            AccountNumber = accountNumber;
            Balance = decimal.Parse(balance);
        }
    }
}
