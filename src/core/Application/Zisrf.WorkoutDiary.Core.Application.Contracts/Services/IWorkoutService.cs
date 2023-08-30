using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;

namespace Zisrf.WorkoutDiary.Core.Application.Contracts.Services;

public interface IWorkoutService
{
    Task<WorkoutDto> CreateWorkoutAsync(DateOnly date, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<WorkoutDto>> GetWorkoutsAsync(CancellationToken cancellationToken = default);

    Task<WorkoutDto> GetWorkoutByIdAsync(Guid workoutId, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ActivityDto>> GetWorkoutActivitiesAsync(
        Guid workoutId,
        CancellationToken cancellationToken = default);

    Task SetWorkoutDateAsync(
        Guid workoutId,
        DateOnly newDate,
        CancellationToken cancellationToken = default);

    Task<ActivityDto> AddActivityAsync(
        Guid workoutId,
        Guid excerciseId,
        int workingWeight,
        int repetitionsCount,
        CancellationToken cancellationToken = default);

    Task RemoveActivityAsync(
        Guid workoutId,
        Guid activityId,
        CancellationToken cancellationToken = default);

    Task RemoveWorkoutByIdAsync(Guid workoutId, CancellationToken cancellationToken = default);
}