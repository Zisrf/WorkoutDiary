using Microsoft.EntityFrameworkCore;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Services;
using Zisrf.WorkoutDiary.Core.Application.Extensions;
using Zisrf.WorkoutDiary.Core.Application.Mapping;
using Zisrf.WorkoutDiary.Core.DataAccess.Abstractions.Contexts;
using Zisrf.WorkoutDiary.Core.Domain.Entities;
using Zisrf.WorkoutDiary.Core.Domain.Extensions;
using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.Application.Services;

internal class WorkoutService : IWorkoutService
{
    private readonly IApplicationDbContext _context;

    public WorkoutService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<WorkoutDto> CreateAsync(DateOnly date, CancellationToken cancellationToken = default)
    {
        var workout = new Workout(Guid.NewGuid(), date);

        _context.Workouts.Add(workout);

        await _context.SaveChangesAsync(cancellationToken);

        return workout.ToDto();
    }

    public async Task<IReadOnlyCollection<WorkoutDto>> GetAsync(CancellationToken cancellationToken = default)
    {
        await _context.Workouts
            .Include(x => x.Activities)
            .LoadAsync(cancellationToken);

        return await _context.Workouts
            .OrderBy(x => x.Date)
            .Select(x => x.ToDto())
            .ToListAsync(cancellationToken);
    }

    public async Task<WorkoutDto> GetByIdAsync(Guid workoutId, CancellationToken cancellationToken = default)
    {
        await _context.Workouts
            .Include(x => x.Activities)
            .LoadAsync(cancellationToken);

        var workout = await _context.Workouts.GetByIdAsync(workoutId, cancellationToken);

        return workout.ToDto();
    }

    public async Task<IReadOnlyCollection<ActivityDto>> GetActivitiesAsync(
        Guid workoutId,
        CancellationToken cancellationToken = default)
    {
        await _context.Workouts
            .Include(x => x.Activities)
            .LoadAsync(cancellationToken);

        await _context.Activities
            .Include(x => x.Exercise)
            .LoadAsync(cancellationToken);

        var workout = await _context.Workouts.GetByIdAsync(workoutId, cancellationToken);

        return workout.Activities
            .Select(x => x.ToDto())
            .ToList();
    }

    public async Task<IReadOnlyCollection<string>> GetInvolvedMuscleGroupsAsync(Guid workoutId,
        CancellationToken cancellationToken = default)
    {
        await _context.Workouts
            .Include(x => x.Activities)
            .LoadAsync(cancellationToken);

        await _context.Activities
            .Include(x => x.Exercise)
            .LoadAsync(cancellationToken);

        var workout = await _context.Workouts.GetByIdAsync(workoutId, cancellationToken);

        return workout
            .GetInvolvedMuscleGroups()
            .Select(x => x.ToString())
            .ToList();
    }

    public async Task<IReadOnlyCollection<string>> GetNotInvolvedMuscleGroupsAsync(Guid workoutId,
        CancellationToken cancellationToken = default)
    {
        await _context.Workouts
            .Include(x => x.Activities)
            .LoadAsync(cancellationToken);

        await _context.Activities
            .Include(x => x.Exercise)
            .LoadAsync(cancellationToken);

        var workout = await _context.Workouts.GetByIdAsync(workoutId, cancellationToken);

        return workout
            .GetNotInvolvedMuscleGroups()
            .Select(x => x.ToString())
            .ToList();
    }

    public async Task UpdateDateAsync(
        Guid workoutId,
        DateOnly newDate,
        CancellationToken cancellationToken = default)
    {
        var workout = await _context.Workouts.GetByIdAsync(workoutId, cancellationToken);

        workout.Date = newDate;

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<ActivityDto> AddActivityAsync(
        Guid workoutId,
        Guid excerciseId,
        double workingWeight,
        int repetitionsCount,
        CancellationToken cancellationToken = default)
    {
        await _context.Workouts
            .Include(x => x.Activities)
            .LoadAsync(cancellationToken);

        var workout = await _context.Workouts.GetByIdAsync(workoutId, cancellationToken);
        var exercise = await _context.Exercises.GetByIdAsync(excerciseId, cancellationToken);

        var activity = workout.CreateActivity(
            Guid.NewGuid(),
            exercise,
            new WorkingWeight(workingWeight),
            new RepetitionsCount(repetitionsCount));

        _context.Activities.Add(activity);

        await _context.SaveChangesAsync(cancellationToken);

        return activity.ToDto();
    }

    public async Task UpdateActivityOrderAsync(
        Guid workoutId,
        Guid activityId,
        int newOrder,
        CancellationToken cancellationToken = default)
    {
        await _context.Workouts
            .Include(x => x.Activities)
            .LoadAsync(cancellationToken);

        var workout = await _context.Workouts.GetByIdAsync(workoutId, cancellationToken);
        var activity = await _context.Activities.GetByIdAsync(activityId, cancellationToken);

        workout.ChangeActivityOrder(activity, new ActivityOrder(newOrder));

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveActivityAsync(
        Guid workoutId,
        Guid activityId,
        CancellationToken cancellationToken = default)
    {
        await _context.Workouts
            .Include(x => x.Activities)
            .LoadAsync(cancellationToken);

        var workout = await _context.Workouts.GetByIdAsync(workoutId, cancellationToken);
        var activity = await _context.Activities.GetByIdAsync(activityId, cancellationToken);

        workout.RemoveActivity(activity);

        _context.Activities.Remove(activity);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveAsync(Guid workoutId, CancellationToken cancellationToken = default)
    {
        await _context.Workouts
            .Include(x => x.Activities)
            .LoadAsync(cancellationToken);

        var workout = await _context.Workouts.GetByIdAsync(workoutId, cancellationToken);

        _context.Activities.RemoveRange(workout.Activities);
        _context.Workouts.Remove(workout);

        await _context.SaveChangesAsync(cancellationToken);
    }
}