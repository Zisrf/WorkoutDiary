using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Services;
using Zisrf.WorkoutDiary.Core.Application.Exceptions.DataAccess;
using Zisrf.WorkoutDiary.Core.Domain.Entities;
using Zisrf.WorkoutDiary.Core.Domain.Exceptions.Models;
using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.Application.Tests.Services;

public class ExerciseServiceTest : ApplicationTestBase
{
    private readonly IExerciseService _exerciseService;

    public ExerciseServiceTest()
    {
        _exerciseService = Services
            .BuildServiceProvider()
            .GetRequiredService<IExerciseService>();
    }

    [Fact]
    public async Task GetNonExistentExercise_ThrowException()
    {
        await Assert.ThrowsAsync<NotFoundException>(
            () => _exerciseService.GetExerciseByIdAsync(Guid.NewGuid()));
    }

    [Fact]
    public async Task GetExistingExercise_NoThrow()
    {
        var exercise = await _exerciseService.CreateExerciseAsync(nameof(Exercise), MuscleGroup.Biceps.ToString());

        await _exerciseService.GetExerciseByIdAsync(exercise.Id);
    }

    [Fact]
    public async Task SetEmptyExerciseName_ThrowException()
    {
        var exercise = await _exerciseService.CreateExerciseAsync(nameof(Exercise), MuscleGroup.Biceps.ToString());

        await Assert.ThrowsAsync<InvalidExerciseNameException>(
            () => _exerciseService.SetExerciseNameAsync(exercise.Id, string.Empty));
    }
}