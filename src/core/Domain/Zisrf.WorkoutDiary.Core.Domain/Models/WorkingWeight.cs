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

    public static implicit operator int(WorkingWeight workingWeight)
    {
        return workingWeight.Value;
    }

    public static implicit operator WorkingWeight(int value)
    {
        return new WorkingWeight(value);
    }
}