using Zisrf.WorkoutDiary.Core.Application.Extensions;
using Zisrf.WorkoutDiary.Core.DataAccess.Extensions;
using Zisrf.WorkoutDiary.Core.WebApi.Controllers.Extensions;
using Zisrf.WorkoutDiary.Web.Configurations;

namespace Zisrf.WorkoutDiary.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection Configure(this IServiceCollection services, Configuration configuration)
    {
        services.AddApplicationServices();

        services.AddApplicationDbContext(configuration.CoreConfiguration.DbConfiguration);

        services
            .AddControllers()
            .WithCoreControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}