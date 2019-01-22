using System;
public class Program
{
    static void Main(string[] args)
    {
        var acc = new global::BankAccount();
        acc.Id = 1;
        acc.Balance = 15;
        Console.WriteLine($"Account {acc.Id}, balance {acc.Balance}");
    }
}