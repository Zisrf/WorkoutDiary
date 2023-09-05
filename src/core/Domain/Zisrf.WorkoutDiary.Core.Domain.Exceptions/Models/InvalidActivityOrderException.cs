using Zisrf.WorkoutDiary.Common.Exceptions.Domain;

namespace Zisrf.WorkoutDiary.Core.Domain.Exceptions.Models;

public class InvalidActivityOrderException : DomainException
{
    public InvalidActivityOrderException()
        : base("Activity order must be greater than or equal to zero and less than the workout activities count")
    {
    }
}