using static System.Console;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account1 = new();
            WriteLine($"{account1.Number} {account1.Balance} {account1.AccountType}");
            WriteLine();

            Account account2 = new(1000, AccountType.Deposit);
            WriteLine($"{account2.Number} {account2.Balance} {account2.AccountType}");
            account2.Put(500);
            WriteLine($"{account2.Number} {account2.Balance} {account2.AccountType}");
            account2.Withdraw(2000);
            WriteLine($"{account2.Number} {account2.Balance} {account2.AccountType}");
            account2.Withdraw(1000);
            WriteLine($"{account2.Number} {account2.Balance} {account2.AccountType}");
        }
    }
}
