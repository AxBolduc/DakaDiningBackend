using DakaDiningBackend.Entities;
using DakaDiningBackend.MealOffers.Contracts.Responses;
using FastEndpoints;

namespace DakaDiningBackend.MealOffers.Mappers;

public class OfferEntityToPurchaseOfferResponse : ResponseMapper<PurchaseOfferResponse, OfferEntity>
{
    private readonly OfferEntityToOfferMapper _offerEntityToOfferMapper;

    public OfferEntityToPurchaseOfferResponse(OfferEntityToOfferMapper offerEntityToOfferMapper)
    {
        _offerEntityToOfferMapper = offerEntityToOfferMapper;
    }

    public override PurchaseOfferResponse FromEntity(OfferEntity e)
    {
        var transformedOffer = _offerEntityToOfferMapper.Transform(e);

        if (transformedOffer == null)
        {
            throw new Exception("Failed to transform offer entity to offer model");
        }

        return new PurchaseOfferResponse()
        {
            Offer = transformedOffer
        };
    }
}
