using System.ComponentModel.DataAnnotations;

namespace DakaDiningBackend.Entities;

public class OfferEntity
{
    [Key]
    public string Id { get; set; }

    public string OfferedById { get; set; }
    public UserEntity OfferedBy { get; set; }

    public float Price { get; set; }

    public DateTime OfferedAt { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public bool Purchased { get; set; }

    public string? PurchasedById { get; set; }
    public UserEntity? PurchasedBy { get; set; }

    public DateTime? PurchasedAt { get; set; }

}
