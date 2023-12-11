namespace DakaDiningBackend.MealOffers.Contracts.Responses;

public class GetOfferByIdResponse
{
    public required string id { get; set; }
    public required string OfferedById { get; set; }
    public required float Price { get; set; }
    public DateTime OfferedAt { get; set; }
    public bool Purchased { get; set; }
    public string? PurchasedById { get; set; }
    public DateTime? PurchasedAt { get; set; }
}
