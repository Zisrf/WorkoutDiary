using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;

namespace Zisrf.WorkoutDiary.Core.Application.Contracts.Services;

public interface IActivityService
{
    Task<ActivityDto> GetActivityById(Guid activityId, CancellationToken cancellationToken = default);

    Task ChangeActivityWorkingWeight(
        Guid activityId,
        int newWorkingWeight,
        CancellationToken cancellationToken = default);

    Task ChangeActivityRepetitionsCount(
        Guid activityId,
        int newRepetitionsCount,
        CancellationToken cancellationToken = default);
}