using System;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                User user = GetUser(context);
                GetInfo(user);
                PayBills(user, 300);
            }
        }

        private static void PayBills(User user, decimal amount)
        {
            var bankAccountSum =
                user.PaymentMethods.Where(x => x.BankAccount != null).Sum(x => x.BankAccount.Balance);
            var creditCardSum =
                user.PaymentMethods.Where(x => x.CreditCard != null).Sum(x => x.CreditCard.LimitLeft);

            var totalSum = bankAccountSum + creditCardSum;

            if (totalSum >= amount)
            {
                var bankAccounts = user.PaymentMethods.Where(x => x.BankAccount != null).Select(x => x.BankAccount).OrderBy(x=>x.BankAccountId).ToArray();

                foreach (var account in bankAccounts)
                {
                    if (account.Balance >= amount)
                    {
                        account.Withdraw(amount);
                        amount = 0;
                    }
                    else
                    {
                        amount -= account.Balance;
                        account.Withdraw(account.Balance);
                    }
                    if (amount == 0)
                    {
                        return;
                        ;
                    }
                }

                var creditCards = user.PaymentMethods.Where(x => x.CreditCard != null).Select(x => x.CreditCard).OrderBy(x => x.CreditCardId);

                foreach (var creditCard in creditCards)
                {
                    if (creditCard.LimitLeft >= amount)
                    {
                        creditCard.Withdraw(amount);
                        amount = 0;
                    }
                    else
                    {
                        amount -= creditCard.LimitLeft;
                        creditCard.Withdraw(creditCard.LimitLeft);
                    }
                    if (amount == 0)
                    {
                        return;
                    }
                }

            }
            else
            {
                Console.WriteLine("Insufficient funds!");
            }
        }

        private static void GetInfo(User user)
        {
            Console.WriteLine($"User: {user.FirstName} {user.LastName}");
            Console.WriteLine("Bank Accounts");

            var bankAccounts = user.PaymentMethods.Where(x => x.BankAccount != null).Select(x => x.BankAccount).ToArray();

            foreach (var account in bankAccounts)
            {
                Console.WriteLine($"-- ID: {account.BankAccountId}");
                Console.WriteLine($"--- Balance: {account.Balance:f2}");
                Console.WriteLine($"--- Bank: {account.BankName}");
                Console.WriteLine($"--- SWIFT: {account.SwiftCode}");
            }

            var creditCards= user.PaymentMethods.Where(x => x.CreditCard != null).Select(x => x.CreditCard).ToArray();

            Console.WriteLine("Credit Cards:");
            foreach (var creaditCard in creditCards)
            {
                Console.WriteLine($"-- ID: {creaditCard.CreditCardId}");
                Console.WriteLine($"--- Limit: {creaditCard.Limit:f2}");
                Console.WriteLine($"--- Money Owed: {creaditCard.MoneyOwed:f2}");
                Console.WriteLine($"--- Limit Left:: {creaditCard.LimitLeft:f2}");
                Console.WriteLine($"--- Expiration Date: {creaditCard.ExpirationDate.ToString("yyyy/MM", CultureInfo.InvariantCulture)}");
            }
        }

        private static User GetUser(BillsPaymentSystemContext context)
        {
            int userId = int.Parse(Console.ReadLine());

            User user = null;

            while (true)
            {
                 user = context.Users
                    .Where(x => x.UserId == userId)
                    .Include(x => x.PaymentMethods)
                    .ThenInclude(x => x.BankAccount)
                    .Include(x => x.PaymentMethods)
                    .ThenInclude(x => x.CreditCard)
                    .FirstOrDefault();

                if (user == null)
                {
                    userId = int.Parse(Console.ReadLine());
                    continue;
                }

                break;
            }

            return user;
        }
    }
}
