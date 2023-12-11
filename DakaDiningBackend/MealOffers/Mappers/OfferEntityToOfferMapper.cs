using DakaDiningBackend.Entities;
using DakaDiningBackend.MealOffers.Models;
using DakaDiningBackend.Shared.Mappers;

namespace DakaDiningBackend.MealOffers.Mappers;

public class OfferEntityToOfferMapper : AbstractMapper<OfferEntity, OfferDto>
{
    protected override OfferDto TransformValue(OfferEntity value)
    {
        return new OfferDto
        {
            Id = value.Id,
            OfferedById = value.OfferedById,
            OfferedAt = value.OfferedAt,
            Price = value.Price,
            Purchased = value.Purchased,
            PurchasedById = value.PurchasedById,
            PurchasedAt = value.PurchasedAt
        };
    }
}
