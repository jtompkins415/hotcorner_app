//Factory for configuring the database context
// Factory reads the connection string from `appsettings.json` & configures the `AppDbContext` with necessary options

using ConsoleApp.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        //Build the configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(System.Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        
        //configure the DbContextOptions
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

        return new AppDbContext(optionsBuilder.Options);
    }
}