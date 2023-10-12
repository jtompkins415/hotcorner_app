// Creating a Database Context for PostgreSQL
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.PostgreSQL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Ingredient> Ingredients {get; set;}
        public DbSet<MenuItem> MenuItems {get; set;}
        public DbSet<Table> Tables {get; set;}
    }
}


