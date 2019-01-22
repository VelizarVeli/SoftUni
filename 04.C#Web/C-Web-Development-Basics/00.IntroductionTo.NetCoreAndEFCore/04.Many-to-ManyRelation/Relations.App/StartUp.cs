using Relations.Data;

namespace Relations.App
{
  public  class StartUp
    {
     public   static void Main()
        {
            var context = new RelationsDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
