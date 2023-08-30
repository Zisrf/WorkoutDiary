using Microsoft.Extensions.DependencyInjection;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Services;
using Zisrf.WorkoutDiary.Core.Application.Services;

namespace Zisrf.WorkoutDiary.Core.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IExerciseService, ExerciseService>();
        services.AddScoped<IActivityService, ActivityService>();
        services.AddScoped<IWorkoutService, WorkoutService>();

        return services;
    }
}