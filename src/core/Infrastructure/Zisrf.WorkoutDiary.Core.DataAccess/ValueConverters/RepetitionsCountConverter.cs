using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.DataAccess.ValueConverters;

internal class RepetitionsCountConverter : ValueConverter<RepetitionsCount, int>
{
    public RepetitionsCountConverter()
        : base(x => x.Value,
            x => new RepetitionsCount(x))
    {
    }
}