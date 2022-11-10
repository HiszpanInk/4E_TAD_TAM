using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_bankowa
{
    //ta klasa dziedziczy po account
    internal class BillingAccount : Account
    {
        //konstruktor
        public BillingAccount(int id, decimal balance, string firstName, string lastName, long pesel)
            : base(id, balance, firstName, lastName, pesel)
        { }

        public override string TypeName()
        {
            return "ROZLICZENIOWE";
        }
        public override void Money(decimal value)
        {
            Balance -= value;
        }
        public void TakeCharge(decimal value)
        {
            Balance -= value;
        }
    }

}
