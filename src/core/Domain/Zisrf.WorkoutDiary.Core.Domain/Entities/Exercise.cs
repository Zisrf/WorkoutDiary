using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.Domain.Entities;

public class Exercise : IEntity
{
    public Exercise(
        Guid id,
        ExerciseName name,
        MuscleGroup muscleGroup)
    {
        Id = id;
        Name = name;
        MuscleGroup = muscleGroup;
    }

    public ExerciseName Name { get; set; }

    public MuscleGroup MuscleGroup { get; set; }

    public Guid Id { get; }
}