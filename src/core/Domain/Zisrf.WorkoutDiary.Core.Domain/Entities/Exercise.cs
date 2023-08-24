using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.Domain.Entities;

public class Exercise
{
    public Exercise(ExerciseName name, MuscleGroup muscleGroup)
    {
        Name = name;
        MuscleGroup = muscleGroup;

        Id = Guid.NewGuid();
    }

    public Guid Id { get; }

    public ExerciseName Name { get; set; }

    public MuscleGroup MuscleGroup { get; set; }
}