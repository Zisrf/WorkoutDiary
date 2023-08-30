using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;

namespace Zisrf.WorkoutDiary.Core.Application.Contracts.Services;

public interface IExerciseService
{
    Task<ExerciseDto> CreateExercise(
        string name,
        string muscleGroup,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ExerciseDto>> GetExercises(CancellationToken cancellationToken = default);

    Task<ExerciseDto> GetExerciseById(Guid exerciseId, CancellationToken cancellationToken = default);

    Task ChangeExerciseName(
        Guid exerciseId,
        string newName,
        CancellationToken cancellationToken = default);

    Task ChangeExerciseMuscleGroup(
        Guid exerciseId,
        string newMuscleGroup,
        CancellationToken cancellationToken = default);

    Task RemoveExerciseById(Guid exerciseId, CancellationToken cancellationToken = default);
}