using DakaDiningBackend.Entities;
using DakaDiningBackend.MealRequests.Contracts.Requests;
using FastEndpoints;

namespace DakaDiningBackend.MealRequests.Mappers;

public class CreateRequestRequestToRequestEntityMapper : RequestMapper<CreateRequestRequest, RequestEntity>
{
    public override RequestEntity ToEntity(CreateRequestRequest r)
    {
        return new RequestEntity()
        {
            Id = Guid.NewGuid().ToString(),
            Price = r.Price,
            Filled = false,
            StartTime = r.StartTime,
            EndTime = r.EndTime,
            RequestedAt = DateTime.UtcNow,
            RequestedById = String.Empty
        };
    }
}
