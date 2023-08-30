using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;

namespace Zisrf.WorkoutDiary.Core.Application.Contracts.Services;

public interface IActivityService
{
    Task<ActivityDto> GetByIdAsync(Guid activityId, CancellationToken cancellationToken = default);

    Task UpdateWorkingWeightAsync(
        Guid activityId,
        double newWorkingWeight,
        CancellationToken cancellationToken = default);

    Task UpdateRepetitionsCountAsync(
        Guid activityId,
        int newRepetitionsCount,
        CancellationToken cancellationToken = default);
}