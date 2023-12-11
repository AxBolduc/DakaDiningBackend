using DakaDiningBackend.Entities;
using DakaDiningBackend.MealRequests.Contracts.Responses;
using DakaDiningBackend.MealRequests.Models;
using FastEndpoints;

namespace DakaDiningBackend.MealRequests.Mappers;

public class RequestEntityToGetRequestByIdResponseMapper : ResponseMapper<GetRequestByIdResponse, RequestEntity>
{
    public override GetRequestByIdResponse FromEntity(RequestEntity entity)
    {
        return new GetRequestByIdResponse()
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
