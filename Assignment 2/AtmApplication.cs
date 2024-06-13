using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Xml.Linq;

public class AtmApplication //creating class AtmApplication
{
    private Bank _bank; //initializing a private bank class

    public AtmApplication(Bank bank) 
    {
        _bank = bank; //setting value of bank class
    }

    public void Run()
    {
        while (true)
        {
            //displaying the main menu
            Console.WriteLine("\n--------------------Welcome to the ATM Main Menu--------------------");
            Console.WriteLine("Choose the following options by the number associated with the option");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Select Account");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            int option = int.Parse(Console.ReadLine());

            //checking user input 
            if (option == 3)
            {
                Console.WriteLine("Are you sure you want to exit? Press 'y' if you want to exit.");
                ConsoleKeyInfo keyInfo = Console.ReadKey(); // Reads a single key press.
                char character = keyInfo.KeyChar;

                if (character == 'y' || character == 'Y' )
                {
                    Console.WriteLine("\nThank you for using ATM application");
                    break;
                }
                else
                {
                    Console.WriteLine("\nYou did not exit");
                    continue;
                }
                
            }

            //using switch case for options
            switch (option)
            {
                case 1:
                    CreateAccount(); 
                    break;
                case 2:
                    SelectAccount();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    //method to create user account
    private void CreateAccount()
    {
        string name;
        int accountNumber;
        float initialBalance;
        float interestRate;
        string accountNumberstr;

        Console.WriteLine("--------------------Create Account--------------------");
        while (true)
        {
            Console.Write("\nEnter Account Holder Name: ");
            name = Console.ReadLine();

            Console.Write("\nEnter Account Number (100-1000): ");
            accountNumberstr = Console.ReadLine();
            if (int.TryParse(accountNumberstr, out accountNumber))
            {
            }
            else 
            {
                Console.WriteLine("The provided account number is not within the range");
                continue;
            }

            Console.Write("\nEnter Initial Balance: ");
            initialBalance = float.Parse(Console.ReadLine());

            Console.Write("\nEnter Annual Interest Rate(Must be less than 3%): ");
            interestRate = float.Parse(Console.ReadLine());

            if ((accountNumber < 100) || (accountNumber > 1000))
            {
                Console.WriteLine("\nAccount number is invalid. Please choose account number between 100 and 1000.");
                Console.WriteLine("________________________________________________________________________________________________________");
            }
            else
            {
                break;
            }

        }

        //adding provided user to account list
        Account newAccount = new Account(name, accountNumber, initialBalance, interestRate);
        _bank.AddAccount(newAccount);
        Console.WriteLine("\nAccount created successfully!");
    }

    //method to display selected account
    private void SelectAccount()
    {
        Console.Write("\nEnter Account Number: ");
        int accountNumber = int.Parse(Console.ReadLine());

        Account account = _bank.GetAccount(accountNumber);
        if (account == null)
        {
            Console.WriteLine("\nAccount not found.");
            return;
        }

        //taking user input to perform action on selected account
        while (true)
        {
            Console.WriteLine("\n--------------------Account Menu--------------------");
            Console.WriteLine($"\nAccount Menu for Account Number: {account.AccountNumber}");
            Console.WriteLine($"Welcome {account.AcctHolderName}");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Display Transactions");
            Console.WriteLine("5. Exit Account");
            Console.Write("Select an option: ");
            int option = int.Parse(Console.ReadLine());

            //checking user input
            if (option == 5)
            {
                break;
            }

            switch (option)
            {
                case 1:
                    Console.WriteLine($"\nBalance: {account.Balance}");
                    break;
                case 2:
                    Console.Write("\nEnter amount to deposit: ");
                    float depositAmount = float.Parse(Console.ReadLine());
                    account.Deposit(depositAmount);
                    Console.WriteLine("\nDeposit successful!");
                    break;
                case 3:
                    Console.Write("\nEnter amount to withdraw: ");
                    float withdrawAmount = float.Parse(Console.ReadLine());
                    try
                    {
                        account.Withdraw(withdrawAmount);
                        Console.WriteLine("\nWithdrawal successful!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case 4:
                    Console.WriteLine("\n--------------------Transaction Log--------------------");
                    Console.WriteLine($"Account Number: {account.AccountNumber}");
                    Console.WriteLine($"Account Holder Name: {account.AcctHolderName}");
                    Console.WriteLine($"Interest rate: {account.AnnualInterestRate}");
                    account.DisplayTransactions();
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    break;
            }
        }
    }
}