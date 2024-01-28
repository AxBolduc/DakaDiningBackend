using DakaDiningBackend.Entities;
using DakaDiningBackend.MealOffers.Services;

namespace DakaDiningBackend.Test.MealOffers.Mocks;

public class MockOffersService : IOffersService
{
    public ICollection<OfferEntity> GetAvailableOffers()
    {
        throw new NotImplementedException();
    }

    public void CreateOffer(OfferEntity offerEntity)
    {
        throw new NotImplementedException();
    }

    public bool DeleteOffer(string offerId)
    {
        throw new NotImplementedException();
    }

    public OfferEntity? GetOfferById(string offerId)
    {
        throw new NotImplementedException();
    }

    public OfferEntity PurchaseOfferById(string offerId, string userId)
    {
        throw new NotImplementedException();
    }
}
