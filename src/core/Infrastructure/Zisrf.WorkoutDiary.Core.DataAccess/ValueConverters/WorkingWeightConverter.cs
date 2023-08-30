using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.DataAccess.ValueConverters;

internal class WorkingWeightConverter : ValueConverter<WorkingWeight, double>
{
    public WorkingWeightConverter()
        : base(x => x.Value,
            x => new WorkingWeight(x))
    {
    }
}