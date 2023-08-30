using Zisrf.WorkoutDiary.Core.Domain.Entities;
using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.Domain.Extensions;

public static class WorkoutExtensions
{
    public static IReadOnlyCollection<MuscleGroup> GetInvolvedMuscleGroups(this Workout workout)
    {
        return workout.Activities
            .Select(x => x.Exercise.MuscleGroup)
            .DistinctBy(x => x)
            .ToList();
    }

    public static IReadOnlyCollection<MuscleGroup> GetNotInvolvedMuscleGroups(this Workout workout)
    {
        return Enum.GetValues<MuscleGroup>()
            .Except(workout.GetInvolvedMuscleGroups())
            .ToList();
    }
}