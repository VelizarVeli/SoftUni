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
                string nameEnd = Console.ReadLine();
                string result = GetAuthorNamesEndingIn(db, nameEnd);
                Console.WriteLine(result);
            }
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => EF.Functions.Like(a.FirstName, "%" + input))
                    .Select(a => new
                    {
                        a.FirstName,
                        a.LastName
                    })
                .OrderBy(x => x.FirstName)
                .ThenBy(x=>x.LastName)
                .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

