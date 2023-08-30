using Microsoft.Extensions.DependencyInjection;
using Zisrf.WorkoutDiary.Core.Application.Extensions;
using Zisrf.WorkoutDiary.Core.DataAccess.Configurations;
using Zisrf.WorkoutDiary.Core.DataAccess.Extensions;

namespace Zisrf.WorkoutDiary.Core.Application.Tests.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureTestServices(this IServiceCollection services)
    {
        services.AddApplicationServices();

        services.AddApplicationDbContext(new InMemoryDbConfiguration
        {
            DbName = Guid.NewGuid().ToString()
        });

        return services;
    }
}