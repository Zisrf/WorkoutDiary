namespace Zisrf.WorkoutDiary.Core.Domain.Exceptions.Models;

public class InvalidWorkingWeightException : DomainException
{
    public InvalidWorkingWeightException()
        : base("Working weight must be greater than zero")
    {
    }
}