namespace Zisrf.WorkoutDiary.Core.DataAccess.Configurations;

public class SqliteDbConfiguration
{
    public string DbName { get; init; } = null!;

    public string GetConnectionString()
    {
        return $"Data Source={DbName}";
    }
}