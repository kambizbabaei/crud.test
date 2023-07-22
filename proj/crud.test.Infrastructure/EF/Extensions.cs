using crud.test.Application.Services;
using crud.test.Domain.Repositories;
using crud.test.Infrastructure.EF.Contexts;
using crud.test.Infrastructure.EF.Options;
using crud.test.Infrastructure.EF.Repositories;
using crud.test.Infrastructure.EF.Services;
using crud.test.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace crud.test.Infrastructure.EF;

internal static class Extensions
{
    public static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductReadServices, ProductsReadService>();

        var options = configuration.GetOptions<DataBaseOptions>("DataBaseConnectionString");
        services.AddDbContext<ReadDbContext>(ctx =>
            ctx.UseSqlServer(options.ConnectionString));
        services.AddDbContext<WriteDbContext>(ctx =>
            ctx.UseSqlServer(options.ConnectionString));

        return services;
    }
}