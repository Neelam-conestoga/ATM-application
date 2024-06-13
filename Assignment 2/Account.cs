using System;
using System.Collections.Generic;
using System.Security.Principal;

public class Account
{
    //defining attributes of an account class
    private string _acctHolderName;
    private int _acctNo;
    private float _annualIntrRate;
    private float _balance;
    private List<string> _transactions;

    // Constructor to initialize the account with necessary details
    public Account(string acctHolderName, int acctNo, float initialBalance, float annualIntrRate)
    {
        _acctHolderName = acctHolderName;
        _acctNo = acctNo;
        _balance = initialBalance;
        _annualIntrRate = annualIntrRate;
        _transactions = new List<string>();
        _transactions.Add($"Account created with initial balance: {initialBalance}");
    }

    // Read-only properties to access private attributes
    public string AcctHolderName => _acctHolderName;
    public int AccountNumber => _acctNo;
    public float Balance => _balance;
    public float AnnualInterestRate => _annualIntrRate;

    // Method to deposit an amount to the account
    public float Deposit(float amount)
    {
        _balance += amount;
        _transactions.Add($"Deposited amount: {amount}, New Balance: {_balance}");
        return _balance;
    }

    // Method to withdraw an amount from the account
    public float Withdraw(float amount)
    {
        if (amount <= _balance)
        {
            _balance -= amount;
            _transactions.Add($"Withdrawn amount: {amount}, New Balance: {_balance}");
        }
        else
        {
            throw new InvalidOperationException("Insufficient funds.");
        }
        return _balance;
    }

    // Method to calculate the monthly interest based on the annual interest rate
    public float GetMonthlyInterest()
    {
        return (_balance * _annualIntrRate) / 12;
    }

    // Method to display all transactions
    public void DisplayTransactions()
    {
        foreach (var transaction in _transactions)
        {
            Console.WriteLine(transaction);
        }
    }
}