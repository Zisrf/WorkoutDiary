﻿using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Services;
using Zisrf.WorkoutDiary.Core.Application.Exceptions.DataAccess;
using Zisrf.WorkoutDiary.Core.Domain.Entities;
using Zisrf.WorkoutDiary.Core.Domain.Exceptions.Models;
using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.Application.Tests.Services;

public class ActivityServiceTest : ApplicationTestBase
{
    private readonly IActivityService _activityService;
    private readonly IExerciseService _exerciseService;
    private readonly IWorkoutService _workoutService;

    public ActivityServiceTest()
    {
        _exerciseService = Services
            .BuildServiceProvider()
            .GetRequiredService<IExerciseService>();

        _activityService = Services
            .BuildServiceProvider()
            .GetRequiredService<IActivityService>();

        _workoutService = Services
            .BuildServiceProvider()
            .GetRequiredService<IWorkoutService>();
    }

    [Fact]
    public async Task GetNonExistentActivity_ThrowException()
    {
        await Assert.ThrowsAsync<NotFoundException>(
            () => _activityService.GetActivityByIdAsync(Guid.NewGuid()));
    }

    [Fact]
    public async Task GetExistingActivity_NoThrow()
    {
        var exercise = await _exerciseService.CreateExerciseAsync(nameof(Exercise), MuscleGroup.Biceps.ToString());
        var workout = await _workoutService.CreateWorkoutAsync(new DateOnly());

        var activity = await _workoutService.AddActivityAsync(
            workout.Id,
            exercise.Id,
            1,
            1);

        await _activityService.GetActivityByIdAsync(activity.Id);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task SetInvalidWorkingWeight_ThrowException(double invalidWorkingWeight)
    {
        var exercise = await _exerciseService.CreateExerciseAsync(nameof(Exercise), MuscleGroup.Biceps.ToString());
        var workout = await _workoutService.CreateWorkoutAsync(new DateOnly());

        var activity = await _workoutService.AddActivityAsync(
            workout.Id,
            exercise.Id,
            1,
            1);

        await Assert.ThrowsAsync<InvalidWorkingWeightException>(
            () => _activityService.SetActivityWorkingWeightAsync(activity.Id, invalidWorkingWeight));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task SetInvalidRepetitionsCount_ThrowException(int invalidRepetitionsCount)
    {
        var exercise = await _exerciseService.CreateExerciseAsync(nameof(Exercise), MuscleGroup.Biceps.ToString());
        var workout = await _workoutService.CreateWorkoutAsync(new DateOnly());

        var activity = await _workoutService.AddActivityAsync(
            workout.Id,
            exercise.Id,
            1,
            1);

        await Assert.ThrowsAsync<InvalidRepetitionsCountException>(
            () => _activityService.SetActivityRepetitionsCountAsync(activity.Id, invalidRepetitionsCount));
    }
}