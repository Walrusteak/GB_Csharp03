﻿namespace Task01
{
    public enum AccountType
    {
        Card,
        Deposit,
        Loan
    }

    public class Account
    {
        private static int _counter = 0;
        private int _number;
        private decimal _balance;
        private AccountType _accountType;

        public int Number
        {
            get => _number;
            set => _number = value;
        }

        public decimal Balance
        {
            get => _balance;
            set => _balance = value;
        }

        public AccountType AccountType
        {
            get => _accountType;
            set => _accountType = value;
        }

        private static int GetCounter() => _counter++;

        public Account() : this(0, AccountType.Card) { }

        public Account(decimal balance) : this(balance, AccountType.Card) { }

        public Account(AccountType accountType) : this(0, accountType) { }

        public Account(decimal balance, AccountType accountType)
        {
            _number = GetCounter();
            _balance = balance;
            _accountType = accountType;
        }

        public void Put(decimal amount) => _balance += amount;

        public bool Withdraw(decimal amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                return true;
            }
            return false;
        }

        public bool TransferHere(Account account, decimal amount)
        {
            if (account.Withdraw(amount))
            {
                Put(amount);
                return true;
            }
            return false;
        }

        public static bool operator ==(Account first, Account second)
        {
            return first._accountType == second._accountType && first._balance == second._balance && first._number == second._number;
        }

        public static bool operator !=(Account first, Account second) => !(first == second);

        public override bool Equals(object obj)
        {
            if (obj is Account account)
                return this == account;
            return false;
        }

        public override int GetHashCode() => base.GetHashCode() ^ _number.GetHashCode() ^ _accountType.GetHashCode() ^ _balance.GetHashCode();
    }
}
