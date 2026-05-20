using BankAccounts;

Account account1 = new Account("Irma Person", "123456", 100.00m);
Account account2 = new Account("A. N. Other", "888888", 40.00m);

account1.Credit(50.0m);
account2.Debit(50.0m);



Console.WriteLine(account1.Balance);
//Console.WriteLine(account2.balance);

List<Account> accounts = new List<Account>();
accounts.Add(account1);
accounts.Add(account2);
accounts.Add(new Account("Hamza", "444444", 150.00m));
accounts.Add(new Account("Zoe", "555555", 4.50m));

// Apply Interest or determine Overdraft Limit
foreach (Account a in accounts)
{
    Console.WriteLine($"{a.ToString()}");
}






