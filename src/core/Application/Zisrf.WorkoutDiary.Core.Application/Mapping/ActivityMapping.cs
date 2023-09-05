using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;
using Zisrf.WorkoutDiary.Core.Domain.Entities;

namespace Zisrf.WorkoutDiary.Core.Application.Mapping;

internal static class ActivityMapping
{
    public static ActivityDto ToDto(this Activity activity)
    {
        return new ActivityDto(
            activity.Id,
            activity.Exercise.Id,
            activity.WorkingWeight.Value,
            activity.RepetitionsCount.Value,
            activity.Order.Value);
    }
}