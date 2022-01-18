using System;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account1 = new(1000, AccountType.Card);
            Account account2 = new(1000, AccountType.Card);
            Console.WriteLine(account1 == account2);
            Console.WriteLine(account1.Equals(account2));
            Console.WriteLine(account1.Equals(new object()));
            account2.Number = account1.Number;
            Console.WriteLine(account1 == account2);
            Console.WriteLine(account1.Equals(account2));
            Console.WriteLine(account1.Equals(new object()));
        }
    }
}
