using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.Domain.Entities;

public class Activity : IEntity
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

    public virtual Exercise Exercise { get; }

    public WorkingWeight WorkingWeight { get; set; }

    public RepetitionsCount RepetitionsCount { get; set; }


    public Guid Id { get; }
}