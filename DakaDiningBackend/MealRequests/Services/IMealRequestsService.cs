using DakaDiningBackend.Entities;

namespace DakaDiningBackend.MealRequests.Services;

public interface IMealRequestsService
{
    ICollection<RequestEntity> GetAvailableRequests();
    void CreateRequest(RequestEntity requestEntity);
    void DeleteRequestById(string requestId);
    RequestEntity GetRequestById(string requestId);
    RequestEntity FillRequestById(string offerId, string userId);
}
