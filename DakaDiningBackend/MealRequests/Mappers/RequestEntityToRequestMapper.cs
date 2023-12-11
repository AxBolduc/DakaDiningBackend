using DakaDiningBackend.Entities;
using DakaDiningBackend.MealRequests.Models;
using DakaDiningBackend.Shared.Mappers;

namespace DakaDiningBackend.MealRequests.Mappers;

public class RequestEntityToRequestMapper : AbstractMapper<RequestEntity, MealRequest>
{
    protected override MealRequest TransformValue(RequestEntity value)
    {
        return new MealRequest()
        {
            Id = value.Id,
            RequestedById = value.RequestedById,
            RequestedAt = value.RequestedAt,
            Price = value.Price,
            StartTime = value.StartTime,
            EndTime = value.EndTime,
            Filled = value.Filled,
            FilledAt = value.FilledAt,
            FilledById = value.FilledById
        };
    }
}
