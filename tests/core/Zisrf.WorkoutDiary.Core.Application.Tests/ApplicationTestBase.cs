using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Zisrf.WorkoutDiary.Core.Application.Tests.Extensions;
using Zisrf.WorkoutDiary.Core.DataAccess.Abstractions.Contexts;

namespace Zisrf.WorkoutDiary.Core.Application.Tests;

public abstract class ApplicationTestBase : IDisposable
{
    protected ApplicationTestBase()
    {
        Services = new ServiceCollection();

        Services.ConfigureTestServices();
    }

    protected IServiceCollection Services { get; }

    public void Dispose()
    {
        var context = Services
            .BuildServiceProvider()
            .GetRequiredService<IApplicationDbContext>();

        if (context is DbContext dbContext)
            dbContext.Database.EnsureDeleted();

        if (context is IDisposable disposable)
            disposable.Dispose();
    }
}