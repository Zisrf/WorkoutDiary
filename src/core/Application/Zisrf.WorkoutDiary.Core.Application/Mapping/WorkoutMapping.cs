using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;
using Zisrf.WorkoutDiary.Core.Domain.Entities;

namespace Zisrf.WorkoutDiary.Core.Application.Mapping;

internal static class WorkoutMapping
{
    public static WorkoutDto ToDto(this Workout workout)
    {
        return new WorkoutDto(
            workout.Id,
            workout.Date,
            workout.Activities
                .Select(x => x.Id)
                .ToList());
    }
}