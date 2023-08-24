using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.Domain.Entities;

public class Workout
{
    private readonly HashSet<Activity> _activities;

    public Workout(DateOnly date)
    {
        Date = date;

        Id = Guid.NewGuid();
        _activities = new HashSet<Activity>();
    }

    public Guid Id { get; }

    public DateOnly Date { get; set; }

    public IReadOnlyCollection<Activity> Activities => _activities;

    public void AddActivity(Activity activity)
    {
        if (_activities.Add(activity) is false)
            throw new NotImplementedException();
    }

    public void RemoveActivity(Activity activity)
    {
        if (_activities.Remove(activity) is false)
            throw new NotImplementedException();
    }

    public IReadOnlyCollection<MuscleGroup> GetInvolvedMuscleGroups()
    {
        return _activities
            .Select(x => x.Exercise.MuscleGroup)
            .DistinctBy(x => x)
            .ToList();
    }

    public IReadOnlyCollection<MuscleGroup> GetNotInvolvedMuscleGroups()
    {
        return Enum.GetValues<MuscleGroup>()
            .Except(GetInvolvedMuscleGroups())
            .ToList();
    }
}