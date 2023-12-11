namespace DakaDiningBackend.MealOffers.Contracts.Responses;

public class GetOfferByIdResponse
{
    public string id { get; set; }
    public string OfferedById { get; set; }
    public float Price { get; set; }
    public DateTime OfferedAt { get; set; }
    public bool Purchased { get; set; }
    public string? PurchasedById { get; set; }
    public DateTime? PurchasedAt { get; set; }
}
