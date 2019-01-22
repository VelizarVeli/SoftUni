using Relations.Data;

namespace Relations.App
{
    class StartUp
    {
     public   static void Main(string[] args)
        {
            var context = new RelationsDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
