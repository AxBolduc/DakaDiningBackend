using DakaDiningBackend.Entities;
using DakaDiningBackend.MealRequests.Contracts.Responses;
using FastEndpoints;

namespace DakaDiningBackend.MealRequests.Mappers;

public class RequestEntityToFillRequestResponseMapper : ResponseMapper<FillRequestResponse, RequestEntity>
{
    public override FillRequestResponse FromEntity(RequestEntity entity)
    {
        return new FillRequestResponse()
        {
            Id = entity.Id,
            RequestedById = entity.RequestedById,
            RequestedAt = entity.RequestedAt,
            Price = entity.Price,
            StartTime = entity.StartTime,
            EndTime = entity.EndTime,
            Filled = entity.Filled,
            FilledAt = entity.FilledAt,
            FilledById = entity.FilledById
        };
    }
}
