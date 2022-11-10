using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplikacja_bankowa
{
    //klasa abstrakcyjna, nie można tworzyć elementów jej klasy, można po niej dziedziczyć
    abstract class Account
    {
        public int Id { get; } //jeśli seta nie będzie to zmienna będzie tylko do odczytu
        public string AccountNumber { get; }
        public decimal Balance { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public long Pesel { get; }

        public Account(int id, decimal balance, string firstName, string lastName, long pesel)
        {
            Id = id;    
            AccountNumber = generateAccountNumber(id);
            Balance = balance;
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
        }
         
        public string GetFullName()
        {
            string fullName = string.Format("{0} {1}", FirstName, LastName);
            return fullName;
        }
        //polimorfizm tu będzie w TypeName(), definicje konkretne są w klasach które dziedziczą po klasie Account
        public abstract string TypeName();
        public abstract void Money(decimal value);
        private string generateAccountNumber(int id)
        {
            string number = string.Format("94{0:D10}", id);
            return number;
        }
        public void ChangeBalance(decimal value)
        {
            Balance += value;
        }
    }
}
