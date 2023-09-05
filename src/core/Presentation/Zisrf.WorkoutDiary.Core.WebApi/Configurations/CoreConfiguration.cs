using Zisrf.WorkoutDiary.Core.DataAccess.Configurations;

namespace Zisrf.WorkoutDiary.Core.WebApi.Configurations;

public class CoreConfiguration
{
    public SqliteDbConfiguration DbConfiguration { get; init; } = null!;
}