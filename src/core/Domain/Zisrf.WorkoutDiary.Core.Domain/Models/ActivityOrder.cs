using Zisrf.WorkoutDiary.Core.Domain.Exceptions.Models;

namespace Zisrf.WorkoutDiary.Core.Domain.Models;

public readonly record struct ActivityOrder : IComparable<ActivityOrder>
{
    public ActivityOrder(int value)
    {
        if (value < 0)
            throw new InvalidActivityOrderException();

        Value = value;
    }

    public int Value { get; }

    public int CompareTo(ActivityOrder other)
    {
        return Value.CompareTo(other.Value);
    }

    public static bool operator <(ActivityOrder activityOrder1, ActivityOrder activityOrder2)
    {
        return activityOrder1.Value < activityOrder2.Value;
    }

    public static bool operator >(ActivityOrder activityOrder1, ActivityOrder activityOrder2)
    {
        return activityOrder1.Value > activityOrder2.Value;
    }

    public static bool operator <=(ActivityOrder activityOrder1, ActivityOrder activityOrder2)
    {
        return activityOrder1.Value <= activityOrder2.Value;
    }

    public static bool operator >=(ActivityOrder activityOrder1, ActivityOrder activityOrder2)
    {
        return activityOrder1.Value >= activityOrder2.Value;
    }

    public static ActivityOrder operator --(ActivityOrder activityOrder)
    {
        return new ActivityOrder(activityOrder.Value - 1);
    }

    public static ActivityOrder operator ++(ActivityOrder activityOrder)
    {
        return new ActivityOrder(activityOrder.Value + 1);
    }
}