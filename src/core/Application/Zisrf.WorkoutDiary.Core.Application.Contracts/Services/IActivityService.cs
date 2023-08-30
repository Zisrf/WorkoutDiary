using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;

namespace Zisrf.WorkoutDiary.Core.Application.Contracts.Services;

public interface IActivityService
{
    Task<ActivityDto> GetActivityByIdAsync(Guid activityId, CancellationToken cancellationToken = default);

    Task SetActivityWorkingWeightAsync(
        Guid activityId,
        double newWorkingWeight,
        CancellationToken cancellationToken = default);

    Task SetActivityRepetitionsCountAsync(
        Guid activityId,
        int newRepetitionsCount,
        CancellationToken cancellationToken = default);
}