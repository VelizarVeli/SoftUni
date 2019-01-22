using System;
using System.Collections.Generic;

namespace _03._1.TestClient
{
    class Program
    {
        static void Main()
        {
            string[] input;
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
            while ((input = Console.ReadLine().Split())[0] != "End")
            {
                string command = input[0];
                switch (command)
                {
                    case "Create":
                        CreateId(input, accounts);
                        break;
                    case "Deposit":
                        Deposit(input, accounts);
                        break;
                    case "Withdraw":
                        Withdraw(input, accounts);
                        break;
                    case "Print":
                        Print(input, accounts);
                        break;
                }
            }
        }

        private static void Print(string[] input, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(input[1]);
            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                Console.WriteLine(accounts[id]);
            }
        }

        private static void Withdraw(string[] input, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(input[1]);
            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else if (accounts[id].Balance < decimal.Parse(input[2]))
            {
                Console.WriteLine($"Insufficient balance");
            }
            else
            {
                accounts[id].Withdraw(decimal.Parse(input[2]));
            }
        }

        private static void Deposit(string[] input, Dictionary<int, BankAccount> accounts)
        {
            int id = int.Parse(input[1]);
            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                accounts[id].Deposit(decimal.Parse(input[2]));
            }
        }

        private static void CreateId(string[] input, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(input[1]);
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine($"Account already exists");
            }
            else
            {
                BankAccount acc = new BankAccount();
                acc.Id = id;
                accounts.Add(id, acc);
            }
        }
    }
}
