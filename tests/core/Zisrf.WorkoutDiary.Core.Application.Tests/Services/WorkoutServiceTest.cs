using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Services;
using Zisrf.WorkoutDiary.Core.Application.Exceptions.DataAccess;

namespace Zisrf.WorkoutDiary.Core.Application.Tests.Services;

public class WorkoutServiceTest : ApplicationTestBase
{
    private readonly IWorkoutService _workoutService;

    public WorkoutServiceTest()
    {
        _workoutService = Services
            .BuildServiceProvider()
            .GetRequiredService<IWorkoutService>();
    }

    [Fact]
    public async Task GetNonExistentWorkout_ThrowException()
    {
        await Assert.ThrowsAsync<NotFoundException>(
            () => _workoutService.GetWorkoutByIdAsync(Guid.NewGuid()));
    }

    [Fact]
    public async Task GetExistingWorkout_NoThrow()
    {
        var workout = await _workoutService.CreateWorkoutAsync(new DateOnly());

        await _workoutService.GetWorkoutByIdAsync(workout.Id);
    }
}