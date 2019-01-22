using System;
using System.Linq;
using BookShop.Models;

namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                string command = Console.ReadLine();
                string result = GetBooksByAgeRestriction(db, command);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var restriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);
            var books = context.Books
                .Where(a => a.AgeRestriction == restriction)
                .OrderBy(x=>x.Title)
                .Select(t=>t.Title)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }
    }
}

