using DakaDiningBackend.Entities;
using DakaDiningBackend.MealOffers.Contracts.Requests;
using FastEndpoints;

namespace DakaDiningBackend.MealOffers.Mappers;

public class OfferRequestToOfferEntityMapper : RequestMapper<CreateOfferRequest, OfferEntity>
{
    private readonly ILogger _logger;

    public OfferRequestToOfferEntityMapper(ILogger<OfferRequestToOfferEntityMapper> logger)
    {
        _logger = logger;
    }

    public override OfferEntity ToEntity(CreateOfferRequest r)
    {
        if (r.Meals < 1)
        {
            const string errMsg = "Can not offer less than 1 meal";
            _logger.LogError(errMsg);
            throw new BadHttpRequestException(errMsg);
        }

        return new OfferEntity()
        {
            Id = Guid.NewGuid().ToString(),
            Price = r.Price,
            Purchased = false,
            OfferedAt = DateTime.UtcNow,
            OfferedById = String.Empty
        };
    }
}
