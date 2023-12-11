using System.ComponentModel.DataAnnotations;

namespace DakaDiningBackend.Entities;

public class UserEntity
{
    [Key]
    public required string UserId { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public int MealSwipes { get; set; }
    public int MealsOffered { get; set; }
    public required string Plan  { get; set; }
    public required string Role { get; set; }
    public string? ProfilePic { get; set; }

    public SessionEntity? Session { get; set; }
    public ICollection<RequestEntity> Requests { get; } = new List<RequestEntity>();
    public ICollection<RequestEntity> RequestsFilled { get; } = new List<RequestEntity>();
    public ICollection<OfferEntity> Offers { get; } = new List<OfferEntity>();
    public ICollection<OfferEntity> OffersFilled { get; } = new List<OfferEntity>();
}
