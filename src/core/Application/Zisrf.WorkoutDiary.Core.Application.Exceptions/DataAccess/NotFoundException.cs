namespace Zisrf.WorkoutDiary.Core.Application.Exceptions.DataAccess;

public class NotFoundException : ApplicationException
{
    private NotFoundException(string message)
        : base(message)
    {
    }

    public static NotFoundException ForEntity<TEntity>(Guid entityId)
    {
        return new NotFoundException($"Entity of type {typeof(TEntity).Name} with id {entityId} was not found");
    }
}