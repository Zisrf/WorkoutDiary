using Zisrf.WorkoutDiary.Core.Domain.Exceptions.Models;

namespace Zisrf.WorkoutDiary.Core.Domain.Models;

public readonly record struct WorkingWeight
{
    public WorkingWeight(int value)
    {
        if (value <= 0)
            throw new InvalidWorkingWeightException();

        Value = value;
    }

    public int Value { get; }
}