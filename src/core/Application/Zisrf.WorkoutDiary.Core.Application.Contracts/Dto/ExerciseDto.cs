namespace Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;

public record ExerciseDto(
    Guid Id,
    string Name,
    string MuscleGroup);