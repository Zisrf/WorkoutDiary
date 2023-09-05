using Microsoft.Extensions.DependencyInjection;
using Zisrf.WorkoutDiary.Core.Application.Extensions;
using Zisrf.WorkoutDiary.Core.DataAccess.Extensions;
using Zisrf.WorkoutDiary.Core.WebApi.Configurations;

namespace Zisrf.WorkoutDiary.Core.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureCore(
        this IServiceCollection services,
        CoreConfiguration configuration)
    {
        services.AddApplicationServices();

        services.AddApplicationDbContext(configuration.DbConfiguration);

        return services;
    }
}