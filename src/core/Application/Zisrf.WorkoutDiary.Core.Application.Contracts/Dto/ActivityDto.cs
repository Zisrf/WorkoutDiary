namespace Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;

public record ActivityDto(
    Guid Id,
    Guid ExerciseId,
    int WorkingWeight,
    int RepetitionsCount);