using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var accounts = new Dictionary<int, BankAccount>();
        string command;

        while ((command = Console.ReadLine()) != "End")
        {
            var splitCommand = command.Split();
            var accountId = int.Parse(splitCommand[1]);
            switch (splitCommand[0])
            {
                case "Create":
                    if (accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account already exists");
                    }
                    else
                    {
                        var account = new BankAccount();
                        account.Id = accountId;
                        accounts.Add(accountId, account);
                    }
                    break;
                case "Deposit":
                    if (ValidateAccountExists(accountId, accounts))
                    {
                        accounts[accountId].Deposit(int.Parse(splitCommand[2]));
                    }
                    break;
                case "Withdraw":
                    if (ValidateAccountExists(accountId, accounts))
                    {
                        accounts[accountId].Withdraw(int.Parse(splitCommand[2]));
                    }
                    break;
                case "Print":

                    if (ValidateAccountExists(accountId,accounts))
                    {
                        Console.WriteLine(accounts[accountId]);
                    }
                    break;
            }
        }
    }

    static bool ValidateAccountExists(int accountId, Dictionary<int, BankAccount> accounts)
    {
        if (accounts.ContainsKey(accountId))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Account does not exist");
            return false;
        }
    }
}