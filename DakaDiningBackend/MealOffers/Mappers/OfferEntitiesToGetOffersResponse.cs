using DakaDiningBackend.Entities;
using DakaDiningBackend.MealOffers.Contracts.Responses;
using FastEndpoints;

namespace DakaDiningBackend.MealOffers.Mappers;

public class OfferEntitiesToGetOffersResponse : ResponseMapper<GetOffersResponse, ICollection<OfferEntity>>
{
    private readonly OfferEntityToOfferMapper _offerEntityToOfferMapper;

    public OfferEntitiesToGetOffersResponse(OfferEntityToOfferMapper offerEntityToOfferMapper)
    {
        _offerEntityToOfferMapper = offerEntityToOfferMapper;
    }

    public override GetOffersResponse FromEntity(ICollection<OfferEntity> e)
    {
        return new GetOffersResponse
        {
            Offers = _offerEntityToOfferMapper.TransformCollection(e)
        };
    }
}
