using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.Domain.Entities;

public class Activity
{
    public Activity(Exercise exercise, WorkingWeight workingWeight, RepetitionsCount repetitionsCount)
    {
        Exercise = exercise;
        WorkingWeight = workingWeight;
        RepetitionsCount = repetitionsCount;

        Id = Guid.NewGuid();
    }


    public Guid Id { get; }

    public Exercise Exercise { get; set; }

    public WorkingWeight WorkingWeight { get; set; }

    public RepetitionsCount RepetitionsCount { get; set; }
}