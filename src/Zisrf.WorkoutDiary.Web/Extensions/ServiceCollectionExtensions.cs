using Zisrf.WorkoutDiary.Core.WebApi.Controllers.Extensions;
using Zisrf.WorkoutDiary.Core.WebApi.Extensions;
using Zisrf.WorkoutDiary.Web.Configurations;

namespace Zisrf.WorkoutDiary.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection Configure(this IServiceCollection services, Configuration configuration)
    {
        services.ConfigureCore(configuration.CoreConfiguration);

        services
            .AddControllers()
            .WithCoreControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}