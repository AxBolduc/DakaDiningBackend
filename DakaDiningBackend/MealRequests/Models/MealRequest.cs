namespace DakaDiningBackend.MealRequests.Models;

public class MealRequest
{
    public required string Id { get; set; }
    public required string RequestedById { get; set; }
    public float Price { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime RequestedAt { get; set; }
    public bool Filled { get; set; }
    public string? FilledById { get; set; }
    public DateTime? FilledAt { get; set; }
}
