using DakaDiningBackend.Entities;
using DakaDiningBackend.MealRequests.Exceptions;

namespace DakaDiningBackend.MealRequests.Services;

public class MealRequestsService : IMealRequestsService
{
    private readonly DakaContext _context;
    private readonly ILogger _logger;

    public MealRequestsService(DakaContext context, ILogger<MealRequestsService> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Retrieves all Requests that have not been filled
    /// </summary>
    /// <returns>A List of Requests that havent been filled</returns>
    public ICollection<RequestEntity> GetAvailableRequests()
    {
        return _context.Requests.Where(r => !r.Filled).ToList();
    }

    /// <summary>
    /// Creates a request in the db
    /// </summary>
    /// <param name="requestEntity">the request entity to create</param>
    public void CreateRequest(RequestEntity requestEntity)
    {
        _context.Requests.Add(requestEntity);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deletes a request entity in the db
    /// </summary>
    /// <param name="requestId">The ID of the request to delete from the db</param>
    /// <exception cref="RequestNotFoundException">When a request with the given request id could not be found</exception>
    public void DeleteRequestById(string requestId)
    {
        try
        {
            RequestEntity existingRequest = GetExistingRequest(requestId);

            _context.Requests.Remove(existingRequest);
            _context.SaveChanges();
        }
        catch (RequestNotFoundException e)
        {
            var errMsg = $"Failed to delete request with id: {requestId}: {e.Message}";
            _logger.LogError(errMsg);
            throw new RequestNotFoundException(errMsg, e);
        }
    }

    /// <summary>
    /// Retrieves a RequestEntity from the db with a given requestId
    /// </summary>
    /// <param name="requestId">Id of the request to retrieve</param>
    /// <returns>A RequestEntity with the given id</returns>
    /// <exception cref="RequestNotFoundException">When a request with the given requestId does not exist</exception>
    public RequestEntity GetRequestById(string requestId)
    {
        try
        {
            return GetExistingRequest(requestId);
        }
        catch (RequestNotFoundException e)
        {
            var errMsg = $"Failed to get request with id: {requestId}: {e.Message}";
            _logger.LogError(errMsg);
            throw new RequestNotFoundException(errMsg, e);
        }
    }

    /// <summary>
    /// Mark a request with a given requestId as filled by a given userId
    /// </summary>
    /// <param name="requestId">Id of the request to mark as filled</param>
    /// <param name="userId">Id of the user who filled the request</param>
    /// <returns>The newly filled RequestEntity</returns>
    /// <exception cref="RequestNotFoundException">When a request with the given requestId does not exist</exception>
    /// <exception cref="RequestAlreadyFilledException">When the request with the given requestId has already been filled </exception>
    public RequestEntity FillRequestById(string requestId, string userId)
    {
        try
        {
            RequestEntity existingRequest = GetExistingRequest(requestId);

            if (existingRequest.Filled)
            {
                var errMsg = $"Failed to fill request with id: {requestId}, request already filled";
                _logger.LogError(errMsg);
                throw new RequestAlreadyFilledException(errMsg);
            }

            existingRequest.Filled = true;
            existingRequest.FilledById = userId;
            existingRequest.FilledAt = DateTime.Now;

            _context.Requests.Update(existingRequest);
            _context.SaveChanges();
            return existingRequest;
        }
        catch (RequestNotFoundException e)
        {
            var errMsg = $"Failed to fill request with id: {requestId}";
            _logger.LogError(errMsg);
            throw new RequestNotFoundException(errMsg, e);
        }
    }

    /// <summary>
    /// Helper function to get an existing request in the db and throw NFE if it does not exist
    /// </summary>
    /// <param name="requestId">ID of the request to find in the db</param>
    /// <returns>The RequestEntity with the given requestId </returns>
    /// <exception cref="RequestNotFoundException">When a request with the given id does not exist</exception>
    private RequestEntity GetExistingRequest(string requestId)
    {
        var existingRequest = _context.Requests.SingleOrDefault(r => r.Id == requestId);

        if (existingRequest == null)
        {
            var errMsg = $"Request with id: {requestId}, does not exist";
            _logger.LogError(errMsg);
            throw new RequestNotFoundException(errMsg);
        }

        return existingRequest;
    }
}
