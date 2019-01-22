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
                string categories = Console.ReadLine();
                string result = GetBooksByCategory(db, categories);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var books = context.Books
                .Where(a => a.BookCategories.Any( c=> categories.Contains(c.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(b => b)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }
    }
}

