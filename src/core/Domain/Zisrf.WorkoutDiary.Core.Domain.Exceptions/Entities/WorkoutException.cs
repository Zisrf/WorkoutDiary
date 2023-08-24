namespace Zisrf.WorkoutDiary.Core.Domain.Exceptions.Entities;

public class WorkoutException : DomainException
{
    private WorkoutException(string message)
        : base(message)
    {
    }

    public static WorkoutException OnAddExistingActivity(Guid workoutId, Guid activityId)
    {
        return new WorkoutException($"Workout {workoutId} already have activity {activityId}");
    }

    public static WorkoutException OnRemoveNonExistentActivity(Guid workoutId, Guid activityId)
    {
        return new WorkoutException($"Workout {workoutId} doesn't have activity {activityId}");
    }
}