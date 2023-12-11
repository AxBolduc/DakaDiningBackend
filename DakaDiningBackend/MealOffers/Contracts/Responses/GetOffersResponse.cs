using DakaDiningBackend.MealOffers.Models;

namespace DakaDiningBackend.MealOffers.Contracts.Responses;

public class GetOffersResponse
{
    public ICollection<OfferDto> Offers { get; set; } = new List<OfferDto>();
}
