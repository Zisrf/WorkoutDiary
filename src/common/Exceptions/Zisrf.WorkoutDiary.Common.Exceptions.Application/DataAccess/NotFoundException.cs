namespace Zisrf.WorkoutDiary.Common.Exceptions.Application.DataAccess;

public class NotFoundException : ApplicationException
{
    private NotFoundException(string message)
        : base(message)
    {
    }

    public static NotFoundException ForEntity<TEntity>(Guid entityId)
        where TEntity : class
    {
        return new NotFoundException($"Entity of type {typeof(TEntity).Name} with id {entityId} was not found");
    }
}