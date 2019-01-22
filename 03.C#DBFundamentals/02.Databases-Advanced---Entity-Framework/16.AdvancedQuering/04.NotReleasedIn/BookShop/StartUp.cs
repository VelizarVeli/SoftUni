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
                int year = int.Parse(Console.ReadLine());
                string result = GetBooksNotRealeasedIn(db, year);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(a => a.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(t => t.Title)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }
    }
}

