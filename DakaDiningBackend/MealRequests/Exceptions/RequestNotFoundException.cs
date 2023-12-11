namespace DakaDiningBackend.MealRequests.Exceptions;

public class RequestNotFoundException : Exception
{
    public RequestNotFoundException()
    {
    }

    public RequestNotFoundException(string? message) : base(message)
    {
    }

    public RequestNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
