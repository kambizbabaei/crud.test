using crud.test.Abstraction.Commands;
using crud.test.Infrastructure.EF;
using crud.test.Infrastructure.Logging;
using crud.test.Shared.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace crud.test.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSQLDB(configuration);
        services.AddQueries();
        services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

        return services;
    }
}