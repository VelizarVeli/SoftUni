using System;
using System.Collections.Generic;
using System.Text;
using IRunesWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace IRunesWebApp.Data
{
    public class IRunesContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Track> Tracks { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=.\SQLEXPRESS;Database=Irunes;Integrated Security = True;")
                .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        
    }
}
