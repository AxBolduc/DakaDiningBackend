using DakaDiningBackend.Entities;
using DakaDiningBackend.MealOffers.Contracts.Requests;
using FastEndpoints;

namespace DakaDiningBackend.MealOffers.Mappers;

public class OfferRequestToOfferEntityMapper : RequestMapper<CreateOfferRequest, OfferEntity>
{
    public override OfferEntity ToEntity(CreateOfferRequest r)
    {
        return new OfferEntity()
        {
            Id = Guid.NewGuid().ToString(),
            Price = r.Price,
            Purchased = false,
            OfferedAt = DateTime.Now,
        };
    }
}
