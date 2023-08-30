using Zisrf.WorkoutDiary.Core.Domain.Exceptions.Models;

namespace Zisrf.WorkoutDiary.Core.Domain.Models;

public readonly record struct WorkingWeight
{
    public WorkingWeight(double value)
    {
        if (value <= 0)
            throw new InvalidWorkingWeightException();

        Value = value;
    }

    public double Value { get; }
}