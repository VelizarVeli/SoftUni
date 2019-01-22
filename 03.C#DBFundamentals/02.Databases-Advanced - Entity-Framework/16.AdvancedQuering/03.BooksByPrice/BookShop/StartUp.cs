using System;
using System.Linq;
using BookShop.Models;

namespace BookShop
{
    using BookShop.Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                string result = GetBooksByPrice(db);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(a => a.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(t => $"{t.Title} - ${t.Price:f2}")
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }
    }
}

