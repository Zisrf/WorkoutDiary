using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.Domain.Entities;

public class Exercise
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

    protected Exercise()
    {
    }

    public Guid Id { get; }

    public ExerciseName Name { get; set; }

    public MuscleGroup MuscleGroup { get; set; }
}