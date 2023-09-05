using Microsoft.Extensions.DependencyInjection;
using Zisrf.WorkoutDiary.Core.DataAccess.Extensions;

namespace Zisrf.WorkoutDiary.Core.WebApi.Extensions;

public static class ServiceScopeExtensions
{
    public static async Task InitializeCoreAsync(this IServiceScope scope)
    {
        await scope.InitializeApplicationDbAsync();
    }
}