namespace Zisrf.WorkoutDiary.Core.WebApi.Abstractions.Requests.Workouts;

public record AddActivityRequest(
    Guid ExerciseId,
    double WorkingWeight,
    int RepetitionsCount);