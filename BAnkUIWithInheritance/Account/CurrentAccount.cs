using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    public class CurrentAccount: Account
    {
        public  decimal OverDraftLimit { get; set; }

        public CurrentAccount(string name, string accountNumber, decimal balance, decimal overdraftLimit): base(name, accountNumber) 
        {
            this.OverDraftLimit = overdraftLimit;
        }

        public override decimal Balance
        {
            get { return balance; }
            set
            {
                if (value < -OverDraftLimit)
                {
                    value = OverDraftLimit;
                }
                balance = value;
            }
        }

        public override decimal Debit(decimal amount)
        {
            if ((Balance - amount) > -OverDraftLimit)
                Balance -= amount;
            return Balance;
        }

        public override string ToString()
        {
            return $"{this.GetType().FullName} for {Name} Account Number: {AccountNumber}'s balance is {Balance:c}. Overdraft Limit is {OverDraftLimit:c}";
        }
    }
}
