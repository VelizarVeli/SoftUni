using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BookShop
{
    using BookShop.Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                string result = GetTotalProfitByCategory(db);
                Console.WriteLine(result);
            }
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            var profit = context.Categories
                .Select(a => new
                {
                    a.Name,
                    TotalProfit = a.CategoryBooks.Sum(s=>s.Book.Price * s.Book.Copies)
                })
                .OrderByDescending(t => t.TotalProfit)
                .ThenBy(a => a.Name)
                .ToArray();
            foreach (var prof in profit)
            {
                sb.AppendLine($"{prof.Name} ${prof.TotalProfit}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

