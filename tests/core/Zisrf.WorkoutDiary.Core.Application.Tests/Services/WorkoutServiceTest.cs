using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Services;
using Zisrf.WorkoutDiary.Core.Application.Exceptions.DataAccess;

namespace Zisrf.WorkoutDiary.Core.Application.Tests.Services;

public class WorkoutServiceTest : ApplicationTestBase
{
    private readonly IExerciseService _exerciseService;
    private readonly IWorkoutService _workoutService;

    public WorkoutServiceTest()
    {
        _exerciseService = Services
            .BuildServiceProvider()
            .GetRequiredService<IExerciseService>();

        _workoutService = Services
            .BuildServiceProvider()
            .GetRequiredService<IWorkoutService>();
    }

    [Fact]
    public async Task GetNonExistentWorkout_ThrowException()
    {
        await Assert.ThrowsAsync<NotFoundException>(
            () => _workoutService.GetByIdAsync(Guid.NewGuid()));
    }

    [Fact]
    public async Task GetExistingWorkout_NoThrow()
    {
        var workout = await _workoutService.CreateAsync(new DateOnly());

        await _workoutService.GetByIdAsync(workout.Id);
    }

    [Fact]
    public async Task UpdateActivitiesOrder_OrderUpdatedCorrectly()
    {
        var exercise = await _exerciseService.CreateAsync("exercise", "Biceps");
        var workout = await _workoutService.CreateAsync(new DateOnly());

        var activities = new[]
        {
            await _workoutService.AddActivityAsync(workout.Id, exercise.Id, 1, 1),
            await _workoutService.AddActivityAsync(workout.Id, exercise.Id, 2, 2),
            await _workoutService.AddActivityAsync(workout.Id, exercise.Id, 3, 3)
        };

        var activityIds = activities
            .Select(x => x.Id)
            .ToList();

        await _workoutService.UpdateActivityOrderAsync(
            workout.Id, activityIds[0], 2);

        var updatedActivies = await _workoutService.GetActivitiesAsync(workout.Id);

        var updatedActivityIds = updatedActivies
            .Select(x => x.Id)
            .ToList();

        Assert.Equal(activityIds[0], updatedActivityIds[2]);
        Assert.Equal(activityIds[1], updatedActivityIds[0]);
        Assert.Equal(activityIds[2], updatedActivityIds[1]);
    }
}