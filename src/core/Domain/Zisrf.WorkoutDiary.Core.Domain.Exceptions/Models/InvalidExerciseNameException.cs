namespace Zisrf.WorkoutDiary.Core.Domain.Exceptions.Models;

public class InvalidExerciseNameException : DomainException
{
    public InvalidExerciseNameException()
        : base("Exercise name can't be empty")
    {
    }
}