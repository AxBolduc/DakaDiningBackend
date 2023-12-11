using DakaDiningBackend.MealRequests.Contracts.Requests;
using DakaDiningBackend.MealRequests.Mappers;
using DakaDiningBackend.MealRequests.Services;
using DakaDiningBackend.Shared;
using FastEndpoints;

namespace DakaDiningBackend.MealRequests.Endpoints;

public class CreateRequestEndpoint : EndpointWithMapper<CreateRequestRequest, CreateRequestRequestToRequestEntityMapper>
{
    private readonly IMealRequestsService _mealRequestsService;
    private readonly ILogger _logger;

    public CreateRequestEndpoint(IMealRequestsService mealRequestsService, ILogger<CreateRequestEndpoint> logger)
    {
        _mealRequestsService = mealRequestsService;
        _logger = logger;
    }

    public override void Configure()
    {
        Post("/api/requests");
        Roles(Constants.PublicEndpointsAllowedRoles);
        Summary(s => { s.Summary = "Create a request"; });
    }

    public override async Task HandleAsync(CreateRequestRequest req, CancellationToken ct)
    {
        var entityFromRequest = Map.ToEntity(req);

        var userId = HttpContext.User.FindFirst("UserId");

        if (userId == null)
        {
            ThrowError("Cannot get user id from request to create an offering");
        }

        entityFromRequest.RequestedById = userId.Value;

        _mealRequestsService.CreateRequest(entityFromRequest);

        await SendCreatedAtAsync<GetRequestByIdEndpoint>(new { RequestId = entityFromRequest.Id }, null,
            cancellation: ct);
    }
}
