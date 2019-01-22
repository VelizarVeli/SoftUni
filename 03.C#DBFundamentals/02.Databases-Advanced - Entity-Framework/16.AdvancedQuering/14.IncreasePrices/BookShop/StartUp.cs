using System;
using System.Globalization;
using System.Linq;
using BookShop.Initializer;
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
               // DbInitializer.ResetDatabase(db);

                IncreasePrices(db);
            }
        }

        public static void IncreasePrices(BookShopContext context)
        {
            context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList()
                .ForEach(p => p.Price += 5);

            context.SaveChanges();
        }
    }
}

