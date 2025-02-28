﻿// Akrit K.C C0895167

using System;

namespace BankAccountApp
{
    public class BankAccount
    {
        // Properties
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public string Type { get; private set; }

        // Constructor for creating a bank account with a specified account number and initial balance.
        public BankAccount(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            Type = "Checking"; // Defaults to a checking account type.
        }

        public BankAccount(string accountNumber, decimal initialBalance, string accountType)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            Type = accountType;
        }

        // Methods
        // Deposits the specified amount into the bank account.
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive");
            }
            Balance += amount;
        }

        // Withdraws the specified amount from the bank account.
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive");
            }
            if (Balance < amount)
            {
                throw new InvalidOperationException("Insufficient funds");
            }
            Balance -= amount;
        }

        // Deposits the specified amount into the bank account with a transaction description.
        public void Deposit(decimal amount, string description)
        {
            Deposit(amount); // Reuse the original Deposit method
        }
        // Withdraws the specified amount from the bank account with a transaction description.
        public void Withdraw(decimal amount, string description)
        {
            Withdraw(amount); // Reuse the original Withdraw method
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a new BankAccount object
            BankAccount myAccount = new BankAccount("123456789", 1000, "Checking");

            // Display initial balance
            Console.WriteLine($"Initial balance: {myAccount.Balance}");

            // Deposit money
            myAccount.Deposit(500);
            Console.WriteLine($"Balance after deposit: {myAccount.Balance}");

            // Withdraw money
            try
            {
                myAccount.Withdraw(200);
                Console.WriteLine($"Balance after withdrawal: {myAccount.Balance}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Withdrawal failed: {ex.Message}");
            }

            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}