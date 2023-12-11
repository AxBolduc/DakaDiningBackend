using DakaDiningBackend.MealOffers.Models;

namespace DakaDiningBackend.MealOffers.Contracts.Responses;

public class PurchaseOfferResponse
{
    public required OfferDto Offer { get; set; }
}
