using P01_HospitalDatabase.Data;

namespace P01_HospitalDatabase
{
  public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new HospitalContext();

            using (context)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}
