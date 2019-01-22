using System;
using System.Linq;

namespace BookShop
{
    using BookShop.Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                int result = RemoveBooks(db);
                Console.WriteLine(result);
            }
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            var countOfBooks = booksToDelete.Count;

            context.Books.RemoveRange(booksToDelete);

            context.SaveChanges();

            return countOfBooks;
        }

        //private static string CapitalizeCommand(string command)
        //{
        //    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        //    command = textInfo.ToTitleCase(command.ToLower());
        //    return command;
        //}
    }
}

