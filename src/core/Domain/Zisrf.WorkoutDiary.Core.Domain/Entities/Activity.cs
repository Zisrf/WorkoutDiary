using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.Domain.Entities;

public class Activity
{
    public Activity(
        Guid id,
        Exercise exercise,
        WorkingWeight workingWeight,
        RepetitionsCount repetitionsCount)
    {
        Id = id;
        Exercise = exercise;
        WorkingWeight = workingWeight;
        RepetitionsCount = repetitionsCount;
    }

    public Guid Id { get; }

    public virtual Exercise Exercise { get; }

    public WorkingWeight WorkingWeight { get; set; }

    public RepetitionsCount RepetitionsCount { get; set; }
}