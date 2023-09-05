using Zisrf.WorkoutDiary.Core.Domain.Exceptions.Entities;
using Zisrf.WorkoutDiary.Core.Domain.Exceptions.Models;
using Zisrf.WorkoutDiary.Core.Domain.Models;

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

    public IReadOnlyCollection<Activity> Activities => _activities
        .OrderBy(x => x.Order)
        .ToList();

    public Activity CreateActivity(
        Guid id,
        Exercise exercise,
        WorkingWeight workingWeight,
        RepetitionsCount repetitionsCount)
    {
        var activity = new Activity(
            id,
            exercise,
            workingWeight,
            repetitionsCount,
            new ActivityOrder(_activities.Count));

        _activities.Add(activity);

        return activity;
    }

    public void RemoveActivity(Activity activity)
    {
        if (_activities.Remove(activity) is false)
            throw WorkoutException.OnGetNonExistentActivity(Id, activity.Id);
    }

    public void ChangeActivityOrder(Activity activity, ActivityOrder newOrder)
    {
        if (newOrder.Value >= _activities.Count)
            throw new InvalidActivityOrderException();

        if (_activities.Contains(activity) is false)
            throw WorkoutException.OnGetNonExistentActivity(Id, activity.Id);

        var previousActivities = _activities
            .Where(x => x.Order >= newOrder && x.Order < activity.Order)
            .ToList();

        foreach (var nextActivity in previousActivities)
            ++nextActivity.Order;

        var nextActivities = _activities
            .Where(x => x.Order > activity.Order && x.Order <= newOrder)
            .ToList();

        foreach (var nextActivity in nextActivities)
            --nextActivity.Order;

        activity.Order = newOrder;
    }
}