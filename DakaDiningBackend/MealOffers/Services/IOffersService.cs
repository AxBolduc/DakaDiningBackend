using DakaDiningBackend.Entities;

namespace DakaDiningBackend.MealOffers.Services;

public interface IOffersService
{
    ICollection<OfferEntity> GetAvailableOffers();
    void CreateOffer(OfferEntity offerEntity);
    bool DeleteOffer(string offerId);
    OfferEntity? GetOfferById(string offerId);
    OfferEntity PurchaseOfferById(string offerId, string userId);
}
