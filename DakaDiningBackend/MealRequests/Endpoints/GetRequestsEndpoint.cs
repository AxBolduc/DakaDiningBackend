using DakaDiningBackend.MealRequests.Contracts.Responses;
using DakaDiningBackend.MealRequests.Mappers;
using DakaDiningBackend.MealRequests.Services;
using DakaDiningBackend.Shared;
using FastEndpoints;

namespace DakaDiningBackend.MealRequests.Endpoints;

public class GetRequestsEndpoint : EndpointWithoutRequest<GetRequestsResponse, RequestEntitiesToGetRequestsResponseMapper>
{
    private readonly IMealRequestsService _mealRequestsService;
    private readonly ILogger _logger;

    public GetRequestsEndpoint(IMealRequestsService mealRequestsService, ILogger<GetRequestsEndpoint> logger)
    {
        _mealRequestsService = mealRequestsService;
        _logger = logger;
    }

    public override void Configure()
    {
        Get("/api/requests");
        Roles(Constants.PublicEndpointsAllowedRoles);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var availableRequests = _mealRequestsService.GetAvailableRequests();

        var response = Map.FromEntity(availableRequests);

        await SendOkAsync(response, ct);
    }
}
