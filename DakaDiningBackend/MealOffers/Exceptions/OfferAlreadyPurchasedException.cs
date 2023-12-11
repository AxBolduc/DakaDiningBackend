namespace DakaDiningBackend.MealOffers.Exceptions;

public class OfferAlreadyPurchasedException: Exception
{
    public OfferAlreadyPurchasedException()
    {
    }

    public OfferAlreadyPurchasedException(string? message) : base(message)
    {
    }
}
