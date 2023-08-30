using Microsoft.EntityFrameworkCore;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Services;
using Zisrf.WorkoutDiary.Core.Application.Extensions;
using Zisrf.WorkoutDiary.Core.Application.Mapping;
using Zisrf.WorkoutDiary.Core.DataAccess.Abstractions.Contexts;
using Zisrf.WorkoutDiary.Core.Domain.Entities;
using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.Application.Services;

internal class WorkoutService : IWorkoutService
{
    private readonly IApplicationDbContext _context;

    public WorkoutService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<WorkoutDto> CreateWorkoutAsync(DateOnly date, CancellationToken cancellationToken = default)
    {
        var workout = new Workout(Guid.NewGuid(), date);

        _context.Workouts.Add(workout);

        await _context.SaveChangesAsync(cancellationToken);

        return workout.ToDto();
    }

    public async Task<IReadOnlyCollection<WorkoutDto>> GetWorkoutsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Workouts
            .OrderBy(x => x.Date)
            .Select(x => x.ToDto())
            .ToListAsync(cancellationToken);
    }

    public async Task<WorkoutDto> GetWorkoutByIdAsync(Guid workoutId, CancellationToken cancellationToken = default)
    {
        var workout = await _context.Workouts.GetByIdAsync(workoutId, cancellationToken);

        return workout.ToDto();
    }

    public async Task<IReadOnlyCollection<ActivityDto>> GetWorkoutActivitiesAsync(
        Guid workoutId,
        CancellationToken cancellationToken = default)
    {
        var workout = await _context.Workouts.GetByIdAsync(workoutId, cancellationToken);

        return workout.Activities
            .Select(x => x.ToDto())
            .ToList();
    }

    public async Task SetWorkoutDateAsync(Guid workoutId, DateOnly newDate,
        CancellationToken cancellationToken = default)
    {
        var workout = await _context.Workouts.GetByIdAsync(workoutId, cancellationToken);

        workout.Date = newDate;

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<ActivityDto> AddActivityAsync(
        Guid workoutId,
        Guid excerciseId,
        int workingWeight,
        int repetitionsCount,
        CancellationToken cancellationToken = default)
    {
        var workout = await _context.Workouts.GetByIdAsync(workoutId, cancellationToken);
        var exercise = await _context.Exercises.GetByIdAsync(excerciseId, cancellationToken);

        var activity = new Activity(
            Guid.NewGuid(),
            exercise,
            new WorkingWeight(workingWeight),
            new RepetitionsCount(repetitionsCount));

        workout.AddActivity(activity);

        _context.Activities.Add(activity);

        await _context.SaveChangesAsync(cancellationToken);

        return activity.ToDto();
    }

    public async Task RemoveActivityAsync(
        Guid workoutId,
        Guid activityId,
        CancellationToken cancellationToken = default)
    {
        var workout = await _context.Workouts.GetByIdAsync(workoutId, cancellationToken);
        var activity = await _context.Activities.GetByIdAsync(activityId, cancellationToken);

        workout.RemoveActivity(activity);

        _context.Activities.Remove(activity);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveWorkoutByIdAsync(Guid workoutId, CancellationToken cancellationToken = default)
    {
        var workout = await _context.Workouts.GetByIdAsync(workoutId, cancellationToken);

        _context.Workouts.Remove(workout);

        await _context.SaveChangesAsync(cancellationToken);
    }
}