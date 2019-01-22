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
                string result = GetBooksByAuthor(db, stringy);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(ba => new
                {
                    BookTitle = ba.Title,
                    FormatedAuthorName = $"({ba.Author.FirstName} {ba.Author.LastName})"
                })
                .ToList()
                .ForEach(t => sb.AppendLine($"{t.BookTitle} {t.FormatedAuthorName}"));


            return sb.ToString();
        }
    }
}

