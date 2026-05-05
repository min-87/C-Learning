using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class BankAccount
    {
        private static List<string> accountNumbers = new List<string>();
        private int accountId;
        private double balance;

        private BankAccount(int accountId, double balance)
        {
            this.accountId = accountId;
            this.balance = balance;
        }
        public static BankAccount CreateAccount(int accountId, double balance)
        {
            string accountNumber = accountId.ToString();
            if (accountNumbers.Contains(accountNumber))
            {
                throw new ArgumentException("Account number already exists.");
            }
            accountNumbers.Add(accountNumber);
            return new BankAccount(accountId, balance);
        }
        public int getAccountNumber()
        {
            return accountId;
        }
        public double getBalance()
        {
            return balance;
        }
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            balance += amount;
        }
        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            balance -= amount;
        }
    }
}
