namespace Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;

public record ActivityDto(
    Guid Id,
    Guid ExerciseId,
    double WorkingWeight,
    int RepetitionsCount,
    int Order);