// Creating a Database Context for PostgreSQL
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HotCorner.Model;

namespace ConsoleApp.PostgreSQL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Ingredient> Ingredients {get; set;}
        public DbSet<MenuItem> MenuItems {get; set;}
        public DbSet<Table> Tables {get; set;}
        public DbSet<Reservation> Reservations {get; set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<Employee> Employees {get; set;}
    }
}


