namespace DakaDiningBackend.Auth.Contracts.Responses;

public class RegisterResponse
{
    public required string UserId { get; set; }
    public required string Token { get; set; }
}
