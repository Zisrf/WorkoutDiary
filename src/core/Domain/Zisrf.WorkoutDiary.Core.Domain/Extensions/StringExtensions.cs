using Zisrf.WorkoutDiary.Core.Domain.Exceptions.Models;
using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.Domain.Extensions;

public static class StringExtensions
{
    public static MuscleGroup ToMuscleGroup(this string str)
    {
        var normalizedStr = $"{str[..1].ToUpper()}{str[1..].ToLower()}";

        if (Enum.TryParse(normalizedStr, out MuscleGroup result) is false)
            throw new InvalidMuscleGroupException(str);

        return result;
    }
}