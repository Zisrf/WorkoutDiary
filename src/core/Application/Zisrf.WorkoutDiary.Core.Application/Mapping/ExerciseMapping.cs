using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;
using Zisrf.WorkoutDiary.Core.Domain.Entities;

namespace Zisrf.WorkoutDiary.Core.Application.Mapping;

internal static class ExerciseMapping
{
    public static ExerciseDto ToDto(this Exercise exercise)
    {
        return new ExerciseDto(
            exercise.Id,
            exercise.Name.Value,
            exercise.MuscleGroup.ToString());
    }
}