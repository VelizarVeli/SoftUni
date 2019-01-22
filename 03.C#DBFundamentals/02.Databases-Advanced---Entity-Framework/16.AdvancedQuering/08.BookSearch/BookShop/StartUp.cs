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
                string stringy = Console.ReadLine();
                string result = GetBookTitlesContaining(db, stringy);
                Console.WriteLine(result);
            }
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(a => EF.Functions.Like(a.Title, $"%{input}%"))
                .Select(a => a.Title)
                .OrderBy(t => t)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }
    }
}

