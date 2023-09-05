using Microsoft.AspNetCore.Builder;
using Zisrf.WorkoutDiary.Common.Exceptions.Handling.Middlewares;

namespace Zisrf.WorkoutDiary.Common.Exceptions.Handling.Extensions;

public static class ApplicationBuidlerExtensions
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseMiddleware<ExceptionHandlingMiddleware>();

        return applicationBuilder;
    }
}