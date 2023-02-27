using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
	/// <summary>
	/// State
	/// </summary>
	public abstract class BankAccountState
	{
		public BankAccount BankAccount { get; protected set; } = null!;
		public decimal Balance { get; protected set; }
		public abstract void Deposit(decimal amount);
		public abstract void Withdraw(decimal amount);
	}

	public class GoldState: BankAccountState
	{
		public GoldState(decimal balance, BankAccount bankAccount)
		{
			Balance = balance;
			BankAccount = bankAccount;
		}
		public override void Deposit(decimal amount)
		{
			Console.WriteLine($"In {GetType()}, deposeting {amount} + 10% {amount /10}");
			Balance += amount + ( amount / 10 );
		}

		public override void Withdraw(decimal amount)
		{
			Console.WriteLine($"In {GetType()}, withdrawing {amount} from {Balance}");
			Balance -= amount;
			if(Balance < 1000 && Balance >=0)
				BankAccount.State = new RegularState(Balance, BankAccount);
			else if(Balance < 0)
				BankAccount.State = new OverdrawnState(Balance, BankAccount);
		}
	}

	/// <summary>
	/// Concrete state
	/// </summary>
	public class RegularState: BankAccountState
	{
		public RegularState(decimal balance, BankAccount bankAccount)
		{
			Balance = balance;
			BankAccount = bankAccount;
		}
		public override void Deposit(decimal amount)
		{
			Console.WriteLine($"In {GetType()}, deposeting {amount}");
			Balance += amount;
			if(Balance >= 1000)
				BankAccount.State = new GoldState(Balance, BankAccount);
		}

		public override void Withdraw(decimal amount)
		{
			Console.WriteLine($"In {GetType()}, withdraowing {amount} from {Balance}");
			Balance -= amount;
			if(Balance < 0)	BankAccount.State = new OverdrawnState(Balance, BankAccount);			
		}
	}

	/// <summary>
	/// Concrete state
	/// </summary>
	public class OverdrawnState: BankAccountState
	{
		public OverdrawnState(decimal balance, BankAccount bankAccount)
		{
			Balance = balance;
			BankAccount = bankAccount;
		}
		public override void Deposit(decimal amount)
		{
			Console.WriteLine($"In {GetType()}, deposeting {amount}");
			Balance += amount;
			if (Balance >= 0) BankAccount.State = new RegularState(Balance, BankAccount);
		}

		public override void Withdraw(decimal amount)
		{
			Console.WriteLine($"In {GetType()}, can not withdrow, balance : {Balance}");
		}
	}

	/// <summary>
	/// Context
	/// </summary>
	public class BankAccount
	{
		public BankAccountState State { get; set; }
		public decimal Balance { get { return State.Balance; } }

		public BankAccount()
		{
			State = new RegularState(200, this);
		}
		public void Deposit(decimal amount)
		{
			State.Deposit(amount);
		}
		public void Withdraw(decimal amount)
		{
			State.Withdraw(amount);
		}
	}
}
