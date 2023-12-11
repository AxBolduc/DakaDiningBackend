namespace DakaDiningBackend.MealRequests.Contracts.Requests;

public class CreateRequestRequest
{
    public float Price { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
