namespace DakaDiningBackend.MealRequests.Exceptions;

public class RequestAlreadyFilledException: Exception
{
    public RequestAlreadyFilledException()
    {
    }

    public RequestAlreadyFilledException(string? message) : base(message)
    {
    }

    public RequestAlreadyFilledException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
