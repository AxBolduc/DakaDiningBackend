namespace DakaDiningBackend.Auth.Contracts.Responses;

public class LoginResponse
{
    public required string UserId { get; set; }

    public required string Token { get; set; }
}
