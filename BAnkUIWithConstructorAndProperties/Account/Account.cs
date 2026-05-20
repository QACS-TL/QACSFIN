using System.Runtime.CompilerServices;

namespace BankAccounts
{
    public class Account
    {
        public Account() : this("Anon")
        {

        }

        public Account(string name) : this(name, accountNumber:"XXXXXX")
        {

        }
        public Account(string name, string accountNumber) : this(name, accountNumber, 0)
        {

        }

        public Account(string name, string accountNumber, decimal balance)
        {
            this.name = name;
            this.accountNumber = accountNumber;
            Balance = balance;
        }

        //public Account(string name = "Anon", string accountNumber="XXXXXX", decimal balance = 0m)
        //{
        //    this.name = name;
        //    this.accountNumber = accountNumber;
        //    Balance = balance;
        //}

        private string name = "Anonymous";

        public string Name
        {
            get { return name; }
            set
            {
                if (name.Length <= 1)
                {
                    return;
                }
                name = value;
            }
        }

        private string accountNumber = "XXXXXX";

        public string AccountNumber
        {
            get { return accountNumber; }
            set
            {
                if (accountNumber.Length != 6)
                {
                    return;
                }
                accountNumber = value;
            }
        } 

        protected  decimal balance = 0;
        private bool disposedValue;

        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                balance = value;
            }
        }

        public decimal Credit(decimal amount) {
            return Balance += amount;
        }



        public decimal Debit(decimal amount) { 
            return Balance -= amount;
        }

        public override string ToString()
        {
            return $"Acc No: {this.AccountNumber}, Name: {this.Name}, Balance: {this.Balance:C}";
        }
    }
}
