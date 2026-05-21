using System.Runtime.CompilerServices;

namespace BankAccounts
{
    // Must Inherit
    public abstract class Account: IComparable<Account>
    {
        // interest rate (static) - Property

        //Create CalcInterest function

        // create and chain constructor

        // introduce overdraft limit

        //public static decimal InterestRate { get; set; } = 0.05M;

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

        public virtual decimal Balance
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



        public abstract decimal Debit(decimal amount); // Must Override

        public override string ToString()
        {
            return $"{this.GetType().FullName} for {Name} Account Number: {AccountNumber}'s balance is {Balance:c}";
        }

        public int CompareTo(Account? other)
        {
            return (int)(this.Balance - other.Balance);
        }

        private static IComparer<Account> accountNameComparer = null;

        public static IComparer<Account> AccountNameComparer
        {
            get { 
                if (accountNameComparer == null)
                {
                    accountNameComparer = new NameComparer();
                }
                return accountNameComparer;
            }
        }

        private class NameComparer : IComparer<Account>
        {
            public int Compare(Account? x, Account? y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }

        private static IComparer<Account> accountNumberComparer = null;

        public static IComparer<Account> AccountNumberComparer
        {
            get
            {
                if (accountNumberComparer == null)
                {
                    accountNumberComparer = new NumberComparer();
                }
                return accountNumberComparer;
            }
        }

        private class NumberComparer : IComparer<Account>
        {
            public int Compare(Account? x, Account? y)
            {
                return x.AccountNumber.CompareTo(y.AccountNumber);
            }
        }
    }
}
