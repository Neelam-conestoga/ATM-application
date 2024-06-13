using System;

public class Program
{
    public static void Main()
    {
        // Create a new instance of the Bank class, which initializes the bank with default accounts
        Bank bank = new Bank();

        // Create a new instance of the AtmApplication class, passing the bank instance to it
        AtmApplication atm = new AtmApplication(bank);

        // Run the ATM application
        atm.Run();
    }
}