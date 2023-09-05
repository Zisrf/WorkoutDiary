namespace Zisrf.WorkoutDiary.Common.Exceptions.Application;

public abstract class ApplicationException : Exception
{
    protected ApplicationException(string message)
        : base(message)
    {
    }
}