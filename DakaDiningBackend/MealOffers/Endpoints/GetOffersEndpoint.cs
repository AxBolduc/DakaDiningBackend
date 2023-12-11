using DakaDiningBackend.Shared.Mappers;
using DakaDiningBackend.MealOffers.Contracts.Responses;
using DakaDiningBackend.MealOffers.Mappers;
using DakaDiningBackend.MealOffers.Services;
using DakaDiningBackend.Shared;
using DakaDiningBackend.Shared.Models;
using FastEndpoints;

namespace DakaDiningBackend.MealOffers.Endpoints;

public class GetOffersEndpoint : EndpointWithoutRequest<GetOffersResponse, OfferEntitiesToGetOffersResponse>
{
    private readonly IOffersService _offersService;

    public GetOffersEndpoint(IOffersService offersService)
    {
        _offersService = offersService;
    }

    public override void Configure()
    {
        Get("/api/offers");
        Roles(Constants.PublicEndpointsAllowedRoles);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var offerEntities = _offersService.GetAvailableOffers();
        var response = Map.FromEntity(offerEntities);

        await SendOkAsync(response, ct);
    }
}
