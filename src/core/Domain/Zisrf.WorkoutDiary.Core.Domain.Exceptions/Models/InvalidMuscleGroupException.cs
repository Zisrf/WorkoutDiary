using Zisrf.WorkoutDiary.Common.Exceptions.Domain;

namespace Zisrf.WorkoutDiary.Core.Domain.Exceptions.Models;

public class InvalidMuscleGroupException : DomainException
{
    public InvalidMuscleGroupException(string muscleGroup)
        : base($"{muscleGroup} is invalid muscle group")
    {
    }
}