using DakaDiningBackend.Entities;
using DakaDiningBackend.Shared.Mappers;
using DakaDiningBackend.MealOffers.Contracts.Requests;
using DakaDiningBackend.MealOffers.Contracts.Responses;
using DakaDiningBackend.MealOffers.Mappers;
using DakaDiningBackend.MealOffers.Services;
using DakaDiningBackend.Shared.Models;
using FastEndpoints;

namespace DakaDiningBackend.MealOffers.Endpoints;

public class GetOfferByIdEndpoint : Endpoint<GetOfferByIdRequest, GetOfferByIdResponse, OfferEntityToGetOfferByIdResponseMapper>
{
    private readonly IOffersService _offersService;
    private readonly ILogger _logger;

    public GetOfferByIdEndpoint(IOffersService offersService, ILogger<GetOfferByIdEndpoint> logger)
    {
        _offersService = offersService;
        _logger = logger;
    }

    public override void Configure()
    {
        Get("/api/offers/{OfferId}");
        Roles(AccountRoleMapper.MapToStrings(new[] { AccountRole.Basic, AccountRole.Admin }).ToArray());
    }

    public override async Task HandleAsync(GetOfferByIdRequest req, CancellationToken ct)
    {
        OfferEntity? requestedOffer = _offersService.GetOfferById(req.OfferId);

        if (requestedOffer == null)
        {
            var errMsg = "Offer with the given id does not exist";
            _logger.LogWarning(errMsg);
            ThrowError(r => r.OfferId, errMsg, StatusCodes.Status404NotFound);
        }

        var offerResponse = Map.FromEntity(requestedOffer);

        await SendOkAsync(offerResponse, ct);
    }
}
