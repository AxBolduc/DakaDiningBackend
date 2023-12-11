namespace DakaDiningBackend.MealOffers.Exceptions;

public class OfferNotFoundException : Exception
{
    public OfferNotFoundException()
    {
    }

    public OfferNotFoundException(string? message) : base(message)
    {
    }

    public OfferNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
