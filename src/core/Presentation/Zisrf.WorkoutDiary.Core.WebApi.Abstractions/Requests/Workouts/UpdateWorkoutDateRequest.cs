namespace Zisrf.WorkoutDiary.Core.WebApi.Abstractions.Requests.Workouts;

public record UpdateWorkoutDateRequest(
    DateOnly NewDate);