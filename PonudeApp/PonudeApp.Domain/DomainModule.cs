using Microsoft.Extensions.DependencyInjection;
using PonudeApp.Domain.Interfaces;
using PonudeApp.Domain.Managers;

namespace PonudeApp.Domain;

public static class DomainModule
{
    public static IServiceCollection AddDomainModule(this IServiceCollection services)
    {
        services.AddTransient<IPonudaManager, PonudaManager>();

        return services;
    }
}
