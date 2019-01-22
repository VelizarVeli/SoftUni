using FDMCBook.Models;
using Microsoft.EntityFrameworkCore;

namespace FDMCBook.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }
        public DbSet<Cat> Cats { get; set; }
    }
}