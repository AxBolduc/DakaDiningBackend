using DakaDiningBackend.Entities;
using DakaDiningBackend.Shared.Mappers;
using DakaDiningBackend.MealOffers.Contracts.Requests;
using DakaDiningBackend.MealOffers.Contracts.Responses;
using DakaDiningBackend.MealOffers.Exceptions;
using DakaDiningBackend.MealOffers.Mappers;
using DakaDiningBackend.MealOffers.Services;
using DakaDiningBackend.Shared.Models;
using FastEndpoints;

namespace DakaDiningBackend.MealOffers.Endpoints;

public class PurchaseOfferEndpoint : Endpoint<PurchaseOfferRequest, PurchaseOfferResponse, OfferEntityToPurchaseOfferResponse>
{
    private readonly IOffersService _offersService;
    private readonly ILogger _logger;

    public PurchaseOfferEndpoint(IOffersService offersService, ILogger<PurchaseOfferEndpoint> logger)
    {
        _offersService = offersService;
        _logger = logger;
    }

    public override void Configure()
    {
        Put("/api/offers/{OfferId}");
        Roles(AccountRoleMapper.MapToStrings(new[] { AccountRole.Basic, AccountRole.Admin }).ToArray());
    }

    public override async Task HandleAsync(PurchaseOfferRequest req, CancellationToken ct)
    {
        // Get purchaser details from auth
        var userId = HttpContext.User.FindFirst("UserId");

        if (userId == null)
        {
            var errMsg = "Cannot get user id from request to create an offering";
            _logger.LogError(errMsg);
            ThrowError(errMsg, StatusCodes.Status401Unauthorized);
        }

        // Update offer with purchase details
        OfferEntity? updatedOffer = null;
        try
        {
            updatedOffer = _offersService.PurchaseOfferById(req.OfferId, userId.Value);
        }
        catch (OfferNotFoundException e)
        {
            ThrowError(r => r.OfferId, e.Message, StatusCodes.Status404NotFound);
        }
        catch (OfferAlreadyPurchasedException e)
        {
            ThrowError(r => r.OfferId, e.Message, StatusCodes.Status409Conflict);
        }
        catch (Exception e)
        {
            ThrowError("Unknown error occured", StatusCodes.Status500InternalServerError);
        }

        var response =  Map.FromEntity(updatedOffer);

        await SendOkAsync(response, ct);
    }
}
