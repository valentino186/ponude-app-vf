using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PonudeApp.Application.Services.Ponuda;
using System.Reflection;

namespace PonudeApp.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddTransient<IPonudaService, PonudaService>();

        return services;
    }
}
