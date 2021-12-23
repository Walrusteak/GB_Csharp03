using System;
using System.IO;
using static System.Console;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(Reverse("123"));
            EmailToFile("../../in.txt", "../../out.txt");


            Account account1 = new(1000, AccountType.Deposit);
            Account account2 = new(2000, AccountType.Deposit);
            WriteLine($"{account1.Number} {account1.Balance} {account1.AccountType}");
            WriteLine($"{account2.Number} {account2.Balance} {account2.AccountType}");
            WriteLine();

            account1.TransferHere(account2, 2500);
            WriteLine($"{account1.Number} {account1.Balance} {account1.AccountType}");
            WriteLine($"{account2.Number} {account2.Balance} {account2.AccountType}");
            WriteLine();

            account1.TransferHere(account2, 500);
            WriteLine($"{account1.Number} {account1.Balance} {account1.AccountType}");
            WriteLine($"{account2.Number} {account2.Balance} {account2.AccountType}");
            WriteLine();
        }

        static string Reverse(string str)
        {
            char[] buf = str.ToCharArray();
            Array.Reverse(buf);
            return new String(buf);
        }

        public static void SearchMail(ref string s)
        {
            string[] split = s.Split('&');
            s = split.Length == 2 ? split[1].Trim() : null;
        }

        public static void EmailToFile(string sourcePath, string destinationPath)
        {
            if (!File.Exists(sourcePath))
                return;

            StreamReader reader = new(sourcePath);
            StreamWriter writer = new(destinationPath);
            string line = reader.ReadLine();
            while (line != null)
            {
                SearchMail(ref line);
                if (line != null)
                    writer.WriteLine(line);
                line = reader.ReadLine();
            }
            reader.Close();
            writer.Close();
        }
    }
}
