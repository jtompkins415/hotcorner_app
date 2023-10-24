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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>()
                .HasMany(m => m.Ingredients)
                .WithMany(i => i.MenuItemsIncluded)
                .UsingEntity<Dictionary <string, object>>(
                    "MenuItemIngredients",
                    j => j
                        .HasOne<Ingredient>()
                        .WithMany()
                        .HasForeignKey("IngredientId"),
                    j => j
                        .HasOne<MenuItem>()
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                );
        }
    }
}


