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
}