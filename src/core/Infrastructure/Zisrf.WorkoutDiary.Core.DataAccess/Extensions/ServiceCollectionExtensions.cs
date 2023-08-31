using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Zisrf.WorkoutDiary.Core.DataAccess.Abstractions.Contexts;
using Zisrf.WorkoutDiary.Core.DataAccess.Configurations;
using Zisrf.WorkoutDiary.Core.DataAccess.Contexts;

namespace Zisrf.WorkoutDiary.Core.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationDbContext(
        this IServiceCollection services,
        SqliteDbConfiguration configuration)
    {
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(x => x
            .UseSqlite(configuration.GetConnectionString()));

        return services;
    }

    public static IServiceCollection AddApplicationDbContext(
        this IServiceCollection services,
        InMemoryDbConfiguration configuration)
    {
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(x => x
            .UseInMemoryDatabase(configuration.DbName));

        return services;
    }
}