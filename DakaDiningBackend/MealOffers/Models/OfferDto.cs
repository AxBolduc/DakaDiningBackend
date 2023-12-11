namespace DakaDiningBackend.MealOffers.Models;

public class OfferDto
{
    public string Id { get; set; }
    public string OfferedById { get; set; }
    public DateTime OfferedAt { get; set; }
    public float Price { get; set; }
    public bool Purchased { get; set; }
    public string? PurchasedById { get; set; }
    public DateTime? PurchasedAt { get; set; }
}
