using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;

namespace Zisrf.WorkoutDiary.Core.Application.Contracts.Services;

public interface IWorkoutService
{
    Task<WorkoutDto> CreateAsync(DateOnly date, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<WorkoutDto>> GetAsync(CancellationToken cancellationToken = default);

    Task<WorkoutDto> GetByIdAsync(Guid workoutId, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ActivityDto>> GetActivitiesAsync(
        Guid workoutId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<string>> GetInvolvedMuscleGroupsAsync(
        Guid workoutId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<string>> GetNotInvolvedMuscleGroupsAsync(
        Guid workoutId,
        CancellationToken cancellationToken = default);

    Task UpdateDateAsync(
        Guid workoutId,
        DateOnly newDate,
        CancellationToken cancellationToken = default);

    Task<ActivityDto> AddActivityAsync(
        Guid workoutId,
        Guid excerciseId,
        double workingWeight,
        int repetitionsCount,
        CancellationToken cancellationToken = default);

    Task RemoveActivityAsync(
        Guid workoutId,
        Guid activityId,
        CancellationToken cancellationToken = default);

    Task RemoveAsync(Guid workoutId, CancellationToken cancellationToken = default);
}