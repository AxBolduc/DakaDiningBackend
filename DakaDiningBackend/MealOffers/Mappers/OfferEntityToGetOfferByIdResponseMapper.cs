using DakaDiningBackend.Entities;
using DakaDiningBackend.MealOffers.Contracts.Responses;
using FastEndpoints;

namespace DakaDiningBackend.MealOffers.Mappers;

public class OfferEntityToGetOfferByIdResponseMapper : ResponseMapper<GetOfferByIdResponse, OfferEntity>
{
    public override GetOfferByIdResponse FromEntity(OfferEntity e)
    {
        return new GetOfferByIdResponse()
        {
            id = e.Id,
            OfferedAt = e.OfferedAt,
            OfferedById = e.OfferedById,
            Price = e.Price,
            Purchased = e.Purchased,
            PurchasedAt = e.PurchasedAt,
            PurchasedById = e.PurchasedById
        };
    }
}
