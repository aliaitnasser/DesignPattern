using State;

Console.Title = "State";

BankAccount BankAccount = new BankAccount();

// should be at regular state
BankAccount.Deposit(100);
BankAccount.Withdraw(100);
BankAccount.Deposit(4000);
// SHould be at Gold state
BankAccount.Withdraw(2000);
BankAccount.Withdraw(3000);
BankAccount.Withdraw(1000);
BankAccount.Deposit(1500);
BankAccount.Withdraw(100);
BankAccount.Deposit(2000);
BankAccount.Withdraw(1000);



