using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.Domain.Entities;

public class Activity
{
    internal Activity(
        Guid id,
        Exercise exercise,
        WorkingWeight workingWeight,
        RepetitionsCount repetitionsCount,
        ActivityOrder order)
    {
        Id = id;
        Exercise = exercise;
        WorkingWeight = workingWeight;
        RepetitionsCount = repetitionsCount;
        Order = order;
    }

    protected Activity()
    {
    }

    public Guid Id { get; }

    public Exercise Exercise { get; }

    public WorkingWeight WorkingWeight { get; set; }

    public RepetitionsCount RepetitionsCount { get; set; }

    public ActivityOrder Order { get; internal set; }
}