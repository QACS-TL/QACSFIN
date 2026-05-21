using BankAccounts;

Account account1 = new SavingsAccount("Irma Person", "123456", 100.00m, 0.10m);
Account account2 = new CurrentAccount("A. N. Other", "888888", 40.00m, 50.0m);

//Account acc = new Account();

account1.Credit(50.0m);
account2.Debit(50.0m);


((SavingsAccount)account1).CalcInterest();

Console.WriteLine(account1.Balance);
//Console.WriteLine(account2.balance);

List<Account> accounts = new List<Account>();
accounts.Add(account1);
accounts.Add(account2);
accounts.Add(new SavingsAccount("Hamza", "444444", 150.00m, 0.05m));
accounts.Add(new CurrentAccount("Zoe", "555555", 4.50m, 100.00m));

// Apply Interest or determine Overdraft Limit
foreach (Account a in accounts)
{
    if (a is SavingsAccount)
    {
        Console.WriteLine($"{a.GetType().FullName} Interest: {((SavingsAccount)a).CalcInterest()}");
    }
    CurrentAccount ca = a as CurrentAccount;
    if (ca != null)
        Console.WriteLine(($"{a.GetType().FullName} Overdraft Limit: {ca.OverDraftLimit}"));
    Console.WriteLine($"{a.ToString()}");
}

foreach (Account a in accounts)
    Console.WriteLine(a);

Console.WriteLine("*************************************");
accounts.Sort();
foreach (Account a in accounts)
    Console.WriteLine(a);

Console.WriteLine("*************************************");
accounts.Sort(Account.AccountNameComparer);
foreach (Account a in accounts)
    Console.WriteLine(a);

Console.WriteLine("*************************************");
accounts.Sort(Account.AccountNumberComparer);
foreach (Account a in accounts)
    Console.WriteLine(a);



