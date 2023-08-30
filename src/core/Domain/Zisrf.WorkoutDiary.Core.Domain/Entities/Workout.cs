using Zisrf.WorkoutDiary.Core.Domain.Exceptions.Entities;

namespace Zisrf.WorkoutDiary.Core.Domain.Entities;

public class Workout
{
    private readonly HashSet<Activity> _activities;

    public Workout(Guid id, DateOnly date)
    {
        Id = id;
        Date = date;

        _activities = new HashSet<Activity>();
    }

    protected Workout()
    {
    }

    public Guid Id { get; }

    public DateOnly Date { get; set; }

    public virtual IReadOnlyCollection<Activity> Activities => _activities;

    public void AddActivity(Activity activity)
    {
        if (_activities.Add(activity) is false)
            throw WorkoutException.OnAddExistingActivity(Id, activity.Id);
    }

    public void RemoveActivity(Activity activity)
    {
        if (_activities.Remove(activity) is false)
            throw WorkoutException.OnRemoveNonExistentActivity(Id, activity.Id);
    }
}