namespace Zisrf.WorkoutDiary.Core.WebApi.Abstractions.Requests.Exercises;

public record CreateExerciseRequest(
    string Name,
    string MuscleGroup);