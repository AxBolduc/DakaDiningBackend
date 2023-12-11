using DakaDiningBackend.MealRequests.Models;

namespace DakaDiningBackend.MealRequests.Contracts.Responses;

public class GetRequestsResponse
{
    public ICollection<MealRequest> Requests { get; set; } = new List<MealRequest>();
}
