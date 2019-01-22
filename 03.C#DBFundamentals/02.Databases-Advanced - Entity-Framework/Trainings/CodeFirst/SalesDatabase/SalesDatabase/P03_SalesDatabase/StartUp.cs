using P03_SalesDatabase.Data;

namespace P03_SalesDatabase
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SalesContext();
            using (context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}
