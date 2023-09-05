using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.DataAccess.ValueConverters;

internal class ActivityOrderConverter : ValueConverter<ActivityOrder, int>
{
    public ActivityOrderConverter()
        : base(x => x.Value, x => new ActivityOrder(x))
    {
    }
}