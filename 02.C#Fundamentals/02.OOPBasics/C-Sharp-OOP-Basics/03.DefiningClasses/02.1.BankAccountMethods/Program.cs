using System;
public class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount();

        acc.Id = 1;
        acc.Deposit(15);
        acc.Withdraw(10);

        Console.WriteLine(acc);
    }
}