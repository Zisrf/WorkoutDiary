using Zisrf.WorkoutDiary.Core.Domain.Exceptions.Models;

namespace Zisrf.WorkoutDiary.Core.Domain.Models;

public readonly record struct ExerciseName
{
    public ExerciseName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidExerciseNameException();

        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(ExerciseName exerciseName)
    {
        return exerciseName.Value;
    }

    public static implicit operator ExerciseName(string value)
    {
        return new ExerciseName(value);
    }
}