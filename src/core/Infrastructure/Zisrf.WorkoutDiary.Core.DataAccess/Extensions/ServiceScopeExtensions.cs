using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Zisrf.WorkoutDiary.Core.DataAccess.Contexts;

namespace Zisrf.WorkoutDiary.Core.DataAccess.Extensions;

public static class ServiceScopeExtensions
{
    public static async Task InitializeDbAsync(this IServiceScope scope)
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await context.Database.MigrateAsync();
    }
}