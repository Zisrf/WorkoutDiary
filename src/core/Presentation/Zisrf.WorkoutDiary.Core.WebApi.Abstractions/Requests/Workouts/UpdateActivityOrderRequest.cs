namespace Zisrf.WorkoutDiary.Core.WebApi.Abstractions.Requests.Workouts;

public record UpdateActivityOrderRequest(
    Guid ActivityId,
    int NewOrder);