using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_bankowa
{
    //ta klasa dziedziczy po klasie Account
    internal class SavingsAccount : Account
    {
        //konstruktor
        public SavingsAccount(int id, decimal balance, string firstName, string lastName, long pesel) 
            : base(id, balance, firstName, lastName, pesel) //i te dane z góry lecą do base i działają na podstawie tamtego konstruktora (no i działa tak jak powinien działać)
        {
        }

        public override string TypeName()
        {
            return "OSZCZĘDNOŚCIOWE";
        }
        public override void Money(decimal value)
        {
            Balance += Balance * value;
        }
        public void AddInterest(decimal interest)
        {
            Balance += Balance * interest;
        }

}
}
