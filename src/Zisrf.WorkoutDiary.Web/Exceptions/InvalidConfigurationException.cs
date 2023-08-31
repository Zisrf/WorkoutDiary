namespace Zisrf.WorkoutDiary.Web.Exceptions;

public class InvalidConfigurationException : Exception
{
    public InvalidConfigurationException()
        : base("Invalid configuration")
    {
    }
}