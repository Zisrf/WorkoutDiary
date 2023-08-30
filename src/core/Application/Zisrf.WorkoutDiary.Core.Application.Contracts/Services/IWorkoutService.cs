using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;

namespace Zisrf.WorkoutDiary.Core.Application.Contracts.Services;

public interface IWorkoutService
{
    Task<WorkoutDto> CreateWorkout(DateOnly date, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<WorkoutDto>> GetWorkouts(CancellationToken cancellationToken = default);

    Task<WorkoutDto> GetWorkoutById(Guid workoutId, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ActivityDto>> GetWorkoutActivities(
        Guid workoutId,
        CancellationToken cancellationToken = default);

    Task ChangeWorkoutDate(
        Guid workoutId,
        DateOnly newDate,
        CancellationToken cancellationToken = default);

    Task AddActivity(
        Guid workoutId,
        Guid excerciseId,
        int workingWeight,
        int repetitionsCount,
        CancellationToken cancellationToken = default);

    Task RemoveActivity(
        Guid workoutId,
        Guid activityId,
        CancellationToken cancellationToken = default);

    Task RemoveWorkoutById(Guid workoutId, CancellationToken cancellationToken = default);
}