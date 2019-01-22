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
                int lengt = int.Parse(Console.ReadLine());
                int result = CountBooks(db, lengt);
                Console.WriteLine(result);
            }
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {

            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Select(t => t.Title)
                .ToArray();


            return books.Length;
        }
    }
}

