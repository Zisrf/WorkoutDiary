using Microsoft.Extensions.DependencyInjection;
using Zisrf.WorkoutDiary.Common.Exceptions.Handling.Middlewares;

namespace Zisrf.WorkoutDiary.Common.Exceptions.Handling.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMiddlewares(this IServiceCollection services)
    {
        services.AddSingleton<ExceptionHandlingMiddleware>();

        return services;
    }
}