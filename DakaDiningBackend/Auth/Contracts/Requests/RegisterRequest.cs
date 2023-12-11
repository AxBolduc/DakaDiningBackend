namespace DakaDiningBackend.Auth.Contracts.Requests;

public class RegisterRequest
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string? Role { get; set; }
    public string? Plan { get; set; }
    public int? MealSwipes { get; set; }
}
