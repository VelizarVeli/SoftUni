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
                string result = GetGoldenBooks(db);
                Console.WriteLine(result);
            }
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(a => a.Copies < 5000 && a.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(t => t.Title)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }
    }
}

