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

        IncreaseActivityOrdersInRange(newOrder, activity.Order);
        DecreaseActivityOrdersInRange(activity.Order, newOrder);

        activity.Order = newOrder;
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

    private void IncreaseActivityOrdersInRange(ActivityOrder left, ActivityOrder right)
    {
        var activities = _activities
            .Where(x => x.Order >= left && x.Order < right)
            .ToList();

        foreach (var activity in activities)
            ++activity.Order;
    }

    private void DecreaseActivityOrdersInRange(ActivityOrder left, ActivityOrder right)
    {
        var activities = _activities
            .Where(x => x.Order > left && x.Order <= right)
            .ToList();

        foreach (var activity in activities)
            --activity.Order;
    }
}