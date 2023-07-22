using crud.test.Domain.Factories;
using crud.test.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace crud.test.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddSingleton<IProductFactory, ProductFactory>();
        return services;
    }
}