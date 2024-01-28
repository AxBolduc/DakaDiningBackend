using DakaDiningBackend.Shared.Mappers;
using DakaDiningBackend.MealOffers.Contracts.Requests;
using DakaDiningBackend.MealOffers.Services;
using DakaDiningBackend.Shared.Models;
using FastEndpoints;

namespace DakaDiningBackend.MealOffers.Endpoints;

public class DeleteOfferEndpoint : Endpoint<DeleteOfferRequest>
{
    private readonly IOffersService _offersService;
    private readonly ILogger _logger;

    public DeleteOfferEndpoint(IOffersService offersService, ILogger<DeleteOfferEndpoint> logger)
    {
        _offersService = offersService;
        _logger = logger;
    }

    public override void Configure()
    {
        Delete("/api/offers/{OfferId}");
        Roles(AccountRoleMapper.MapToStrings(new[] { AccountRole.Admin }).ToArray());
    }

    public override async Task HandleAsync(DeleteOfferRequest req, CancellationToken ct)
    {
        var offerId = req.OfferId;
        var wasDeleted = _offersService.DeleteOffer(offerId);

        if (!wasDeleted) {
            var errMsg = "Failed to find an order with the given id";
            _logger.LogWarning(errMsg);
            ThrowError(o => o.OfferId, errMsg, StatusCodes.Status404NotFound);
        }

        await SendNoContentAsync(ct);
    }
}
