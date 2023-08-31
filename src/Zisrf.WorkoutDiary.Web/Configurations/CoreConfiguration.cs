using Zisrf.WorkoutDiary.Core.DataAccess.Configurations;

namespace Zisrf.WorkoutDiary.Web.Configurations;

public class CoreConfiguration
{
    public SqliteDbConfiguration DbConfiguration { get; init; } = null!;
}