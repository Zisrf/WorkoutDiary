namespace Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;

public record WorkoutDto(
    Guid Id,
    DateOnly Date,
    IReadOnlyCollection<Guid> ActivityIds);