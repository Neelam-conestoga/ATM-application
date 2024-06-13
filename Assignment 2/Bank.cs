using System;
using System.Collections.Generic;
using System.Security.Principal;

public class Bank
{
    // List to store multiple Account objects
    private List<Account> _accountList;

    // Constructor to initialize the bank with default accounts
    public Bank()
    {
        _accountList = new List<Account>();
        for (int k = 100; k < 110; k++)
        {
            _accountList.Add(new Account($"Default Account {k}", k, 100, 3f));
        }
    }

    // Method to retrieve an account based on the account number
    public Account GetAccount(int accountNumber)
    {
        // Finds and returns the account that matches the given account number
        return _accountList.Find(acc => acc.AccountNumber == accountNumber);
    }

    // Method to add a new account to the bank's account list
    public void AddAccount(Account account)
    {
        // Adds the provided account to the account list
        _accountList.Add(account);
    }
}