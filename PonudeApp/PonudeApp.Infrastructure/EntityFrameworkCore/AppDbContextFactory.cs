using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PonudeApp.Infrastructure.EntityFrameworkCore;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var dbContextBuilder = new DbContextOptionsBuilder<AppDbContext>();

        dbContextBuilder.UseSqlServer(configuration.GetConnectionString("Default"));

        return new AppDbContext(dbContextBuilder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../PonudeApp.API/"))
            .AddJsonFile("appsettings.json", false);

        return builder.Build();
    }
}
