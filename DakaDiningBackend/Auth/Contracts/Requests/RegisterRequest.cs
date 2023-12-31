namespace DakaDiningBackend.Auth.Contracts.Requests;

public class RegisterRequest
{
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Password { get; set; }
    public string? Plan { get; set; }
    public int? MealSwipes { get; set; }
}
