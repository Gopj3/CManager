using CManagerData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CManagerAPI;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configuration = WebApplication
            .CreateBuilder(args).Configuration;
        configuration.SetBasePath(Directory.GetCurrentDirectory());
        configuration.AddJsonFile("appsettings.Development.json");
        string connectionString = configuration.GetConnectionString("Database");
        
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}