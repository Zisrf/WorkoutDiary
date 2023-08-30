using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.DataAccess.ValueConverters;

internal class ExerciseNameConverter : ValueConverter<ExerciseName, string>
{
    public ExerciseNameConverter()
        : base(x => x.Value,
            x => new ExerciseName(x))
    {
    }
}