using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;

namespace Zisrf.WorkoutDiary.Core.Application.Contracts.Services;

public interface IExerciseService
{
    Task<ExerciseDto> CreateAsync(
        string name,
        string muscleGroup,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<ExerciseDto>> GetAsync(CancellationToken cancellationToken = default);

    Task<ExerciseDto> GetByIdAsync(Guid exerciseId, CancellationToken cancellationToken = default);

    Task UpdateNameAsync(
        Guid exerciseId,
        string newName,
        CancellationToken cancellationToken = default);

    Task UpdateMuscleGroupAsync(
        Guid exerciseId,
        string newMuscleGroup,
        CancellationToken cancellationToken = default);

    Task RemoveAsync(Guid exerciseId, CancellationToken cancellationToken = default);
}