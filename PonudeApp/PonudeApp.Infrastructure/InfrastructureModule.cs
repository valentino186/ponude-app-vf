using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PonudeApp.Domain.Interfaces;
using PonudeApp.Infrastructure.EntityFrameworkCore;
using PonudeApp.Infrastructure.EntityFrameworkCore.Repositories;
using PonudeApp.Infrastructure.EntityFrameworkCore.Repositories.Common;

namespace PonudeApp.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        services.AddTransient<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IPonudaRepository, PonudaRepository>();

        return services;
    }
}
