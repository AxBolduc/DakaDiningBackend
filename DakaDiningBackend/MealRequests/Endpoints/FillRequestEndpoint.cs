using DakaDiningBackend.MealRequests.Contracts.Requests;
using DakaDiningBackend.MealRequests.Contracts.Responses;
using DakaDiningBackend.MealRequests.Exceptions;
using DakaDiningBackend.MealRequests.Mappers;
using DakaDiningBackend.MealRequests.Services;
using DakaDiningBackend.Shared;
using FastEndpoints;

namespace DakaDiningBackend.MealRequests.Endpoints;

public class
    FillRequestEndpoint : Endpoint<FillRequestRequest, FillRequestResponse, RequestEntityToFillRequestResponseMapper>
{
    private readonly IMealRequestsService _mealRequestsService;
    private readonly ILogger _logger;

    public FillRequestEndpoint(IMealRequestsService mealRequestsService, ILogger<FillRequestEndpoint> logger)
    {
        _mealRequestsService = mealRequestsService;
        _logger = logger;
    }

    public override void Configure()
    {
        Post("/api/requests/{RequestId}");
        Roles(Constants.PublicEndpointsAllowedRoles);
    }

    public override async Task HandleAsync(FillRequestRequest req, CancellationToken ct)
    {
        var userId = HttpContext.User.FindFirst("UserId");

        if (userId == null)
        {
            var errMsg = "Cannot get user id from request to create an offering";
            _logger.LogError(errMsg);
            ThrowError(errMsg, StatusCodes.Status401Unauthorized);
        }

        try
        {
            var filledRequest = _mealRequestsService.FillRequestById(req.RequestId, userId.Value);

            var response = Map.FromEntity(filledRequest);

            await SendOkAsync(response, ct);
        }
        catch (RequestNotFoundException e)
        {
            ThrowError(r => r.RequestId, e.Message, StatusCodes.Status404NotFound);
        }
        catch (RequestAlreadyFilledException e)
        {
            ThrowError(r => r.RequestId, e.Message, StatusCodes.Status409Conflict);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            ThrowError("Unknown Error Occured", StatusCodes.Status500InternalServerError);
        }
    }
}
