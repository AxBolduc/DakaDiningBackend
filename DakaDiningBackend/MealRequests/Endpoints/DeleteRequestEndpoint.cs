using DakaDiningBackend.MealRequests.Contracts.Requests;
using DakaDiningBackend.MealRequests.Exceptions;
using DakaDiningBackend.MealRequests.Services;
using DakaDiningBackend.Shared.Mappers;
using DakaDiningBackend.Shared.Models;
using FastEndpoints;

namespace DakaDiningBackend.MealRequests.Endpoints;

public class DeleteRequestEndpoint : Endpoint<DeleteRequestRequest>
{
    private readonly IMealRequestsService _mealRequestsService;
    private readonly ILogger _logger;

    public DeleteRequestEndpoint(IMealRequestsService mealRequestsService, ILogger<DeleteRequestEndpoint> logger)
    {
        _mealRequestsService = mealRequestsService;
        _logger = logger;
    }

    public override void Configure()
    {
        Delete("/api/requests/{RequestId}");
        Roles(AccountRoleMapper.MapToStrings(new[] { AccountRole.Admin }).ToArray());
    }

    public override async Task HandleAsync(DeleteRequestRequest req, CancellationToken ct)
    {
        try
        {
            _mealRequestsService.DeleteRequestById(req.RequestId);

            await SendNoContentAsync(ct);
        }
        catch (RequestNotFoundException e)
        {
            ThrowError(r => r.RequestId, e.Message, StatusCodes.Status404NotFound);
        }
    }

}
