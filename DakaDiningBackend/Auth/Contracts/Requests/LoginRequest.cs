namespace DakaDiningBackend.Auth.Contracts.Requests;

public class LoginRequest
{
    public string email { get; set; }

    public string password { get; set; }
}
