using System;
using System.Collections.Generic;
using System.Text;
using Eventures.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eventures.Data
{
    public class ApplicationDbContext : IdentityDbContext<EventuresUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
            : base()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>();
            dbContextOptions .UseSqlServer
                ("Server=.\\SQLEXPRESS;Database=Eventures;Trusted_Connection=True;MultipleActiveResultSets=true");
            
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<CustomLog> Logs { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
