using DakaDiningBackend.Entities;
using DakaDiningBackend.MealRequests.Contracts.Responses;
using FastEndpoints;

namespace DakaDiningBackend.MealRequests.Mappers;

public class RequestEntitiesToGetRequestsResponseMapper : ResponseMapper<GetRequestsResponse, ICollection<RequestEntity>>
{
    private readonly RequestEntityToRequestMapper _mapper;

    public RequestEntitiesToGetRequestsResponseMapper(RequestEntityToRequestMapper mapper)
    {
        _mapper = mapper;
    }

    public override GetRequestsResponse FromEntity(ICollection<RequestEntity> e)
    {
        var transformedRequests = _mapper.TransformCollection(e);

        return new GetRequestsResponse()
        {
            Requests = transformedRequests
        };
    }
}
