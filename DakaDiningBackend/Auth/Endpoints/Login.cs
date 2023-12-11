using DakaDiningBackend.Auth.Contracts.Requests;
using DakaDiningBackend.Auth.Contracts.Responses;
using DakaDiningBackend.Entities;
using FastEndpoints;
using FastEndpoints.Security;

namespace DakaDiningBackend.Auth.Endpoints;

public class Login : Endpoint<LoginRequest, LoginResponse>
{
    private readonly DakaContext _context;
    private readonly ILogger _logger;

    public Login(DakaContext context, ILogger<Login> logger)
    {
        _context = context;
        _logger = logger;
    }

    public override void Configure()
    {
        Post("/auth/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        UserEntity? user = _context.Users.SingleOrDefault(user => user.Email == req.Email);

        if (user == null)
        {
            ThrowError(r => r.Email, "A user with the given email does not exist.", StatusCodes.Status404NotFound);
        }

        if (BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
        {
            var jwtToken = JWTBearer.CreateToken(
                signingKey: "THIS_IS_A_SECRET",
                expireAt: DateTime.UtcNow.AddDays(1),
                privileges: u =>
                {
                    u.Roles.Add(user.Role);
                    u.Permissions.AddRange(new[] { "OfferSwipes", "RequestSwipes", "FillRequests", "PurchaseOffers" });
                    u.Claims.Add(new("Email", req.Email));
                    u["UserId"] = user.UserId;
                }
            );

            // Success
            await SendOkAsync(new LoginResponse()
            {
                UserId = user.UserId,
                Token = jwtToken
            }, ct);
        }
    }
}
