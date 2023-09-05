using Zisrf.WorkoutDiary.Core.WebApi.Configurations;
using Zisrf.WorkoutDiary.Web.Exceptions;

namespace Zisrf.WorkoutDiary.Web.Configurations;

public class Configuration
{
    public CoreConfiguration CoreConfiguration { get; init; } = null!;

    public static Configuration Parse(IConfiguration configuration)
    {
        var result = configuration.Get<Configuration>();

        if (result is null)
            throw new InvalidConfigurationException();

        return result;
    }
}