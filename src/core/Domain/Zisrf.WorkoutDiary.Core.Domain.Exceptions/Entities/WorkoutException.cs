using Zisrf.WorkoutDiary.Common.Exceptions.Domain;

namespace Zisrf.WorkoutDiary.Core.Domain.Exceptions.Entities;

public class WorkoutException : DomainException
{
    private WorkoutException(string message)
        : base(message)
    {
    }

    public static WorkoutException OnGetNonExistentActivity(Guid workoutId, Guid activityId)
    {
        return new WorkoutException($"Workout {workoutId} doesn't have activity {activityId}");
    }
}