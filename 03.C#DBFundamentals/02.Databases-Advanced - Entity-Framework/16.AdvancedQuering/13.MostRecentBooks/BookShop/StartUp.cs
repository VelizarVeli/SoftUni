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
                string result = GetMostRecentBooks(db);
                Console.WriteLine(result);
            }
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categories = context.Categories
                .OrderBy(x => x.Name)
                .Select(a => new
                {
                    a.Name,
                    Books = a.CategoryBooks.Select(n => new
                    {
                        n.Book.Title,
                        ReleaseYear = n.Book.ReleaseDate
                    })
                        .OrderByDescending(r => r.ReleaseYear)
                        .Take(3)
                        .ToArray()
                })
                .ToArray();
            
            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseYear.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}

