using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;

namespace Zisrf.WorkoutDiary.Core.Application.Contracts.Services;

public interface IExerciseService
{
    Task<ExerciseDto> CreateExerciseAsync(
        string name,
        string muscleGroup,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ExerciseDto>> GetExercisesAsync(CancellationToken cancellationToken = default);

    Task<ExerciseDto> GetExerciseByIdAsync(Guid exerciseId, CancellationToken cancellationToken = default);

    Task SetExerciseNameAsync(
        Guid exerciseId,
        string newName,
        CancellationToken cancellationToken = default);

    Task SetExerciseMuscleGroupAsync(
        Guid exerciseId,
        string newMuscleGroup,
        CancellationToken cancellationToken = default);

    Task RemoveExerciseByIdAsync(Guid exerciseId, CancellationToken cancellationToken = default);
}