using Microsoft.EntityFrameworkCore;
using Zisrf.WorkoutDiary.Core.Application.Exceptions.DataAccess;

namespace Zisrf.WorkoutDiary.Core.Application.Extensions;

public static class DbSetExtensions
{
    public static async Task<TEntity> GetByIdAsync<TEntity>(
        this DbSet<TEntity> dbSet,
        Guid entityId,
        CancellationToken cancellationToken = default)
        where TEntity : class
    {
        var entity = await dbSet.FindAsync(new object?[] { entityId }, cancellationToken);

        if (entity is null)
            throw NotFoundException.ForEntity<TEntity>(entityId);

        return entity;
    }
}