namespace Zisrf.WorkoutDiary.Core.Domain.Exceptions.Models;

public class InvalidRepetitionsCountException : DomainException
{
    public InvalidRepetitionsCountException()
        : base("Repetitions count must be greater than zero")
    {
    }
}