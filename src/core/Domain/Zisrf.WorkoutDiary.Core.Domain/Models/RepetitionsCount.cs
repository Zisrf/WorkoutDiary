using Zisrf.WorkoutDiary.Core.Domain.Exceptions.Models;

namespace Zisrf.WorkoutDiary.Core.Domain.Models;

public readonly record struct RepetitionsCount
{
    public RepetitionsCount(int value)
    {
        if (value <= 0)
            throw new InvalidRepetitionsCountException();

        Value = value;
    }

    public int Value { get; }

    public static implicit operator int(RepetitionsCount repetitionsCount)
    {
        return repetitionsCount.Value;
    }

    public static implicit operator RepetitionsCount(int value)
    {
        return new RepetitionsCount(value);
    }
}