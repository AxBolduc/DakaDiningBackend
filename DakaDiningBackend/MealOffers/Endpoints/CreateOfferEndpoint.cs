using DakaDiningBackend.Entities;
using DakaDiningBackend.Shared.Mappers;
using DakaDiningBackend.MealOffers.Contracts.Requests;
using DakaDiningBackend.MealOffers.Mappers;
using DakaDiningBackend.MealOffers.Services;
using DakaDiningBackend.Shared.Models;
using FastEndpoints;

namespace DakaDiningBackend.MealOffers.Endpoints;

public class CreateOfferEndpoint : EndpointWithMapper<CreateOfferRequest, OfferRequestToOfferEntityMapper>
{
    private readonly IOffersService _offersService;

    public CreateOfferEndpoint(IOffersService offersService)
    {
        _offersService = offersService;
    }

    public override void Configure()
    {
        Post("/api/offers");
        Roles(AccountRoleMapper.MapToStrings(new[] { AccountRole.Admin, AccountRole.Basic }).ToArray());
    }

    public override async Task HandleAsync(CreateOfferRequest req, CancellationToken ct)
    {
        OfferEntity offerEntity = Map.ToEntity(req);
        var userId = HttpContext.User.FindFirst("UserId");

        if (userId == null)
        {
            ThrowError("Cannot get user id from request to create an offering");
        }

        offerEntity.OfferedById = userId.Value;

        _offersService.CreateOffer(offerEntity);

        await SendCreatedAtAsync<GetOfferByIdEndpoint>(new { OfferId = offerEntity.Id }, null, cancellation: ct);
    }
}
