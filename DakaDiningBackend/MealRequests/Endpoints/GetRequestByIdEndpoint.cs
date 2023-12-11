using DakaDiningBackend.MealRequests.Contracts.Requests;
using DakaDiningBackend.MealRequests.Contracts.Responses;
using DakaDiningBackend.MealRequests.Mappers;
using DakaDiningBackend.MealRequests.Services;
using FastEndpoints;
using Constants = DakaDiningBackend.Shared.Constants;

namespace DakaDiningBackend.MealRequests.Endpoints;

public class GetRequestByIdEndpoint : Endpoint<GetRequestByIdRequest, GetRequestByIdResponse, RequestEntityToGetRequestByIdResponseMapper>
{
    private readonly IMealRequestsService _mealRequestsService;
    private readonly ILogger _logger;

    public GetRequestByIdEndpoint(IMealRequestsService mealRequestsService, ILogger<GetRequestsEndpoint> logger)
    {
        _mealRequestsService = mealRequestsService;
        _logger = logger;
    }

    public override void Configure()
    {
        Get("/api/requests/{RequestId}");
        Roles(Constants.PublicEndpointsAllowedRoles);
        Summary(s =>
        {
            s.Summary = "Gets a single request with a given RequestId";
        });
    }

    public override async Task HandleAsync(GetRequestByIdRequest req, CancellationToken ct)
    {
        var requestEntity = _mealRequestsService.GetRequestById(req.RequestId);

        var response = Map.FromEntity(requestEntity);

        await SendOkAsync(response, ct);
    }
}
