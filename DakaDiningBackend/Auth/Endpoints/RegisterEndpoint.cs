using DakaDiningBackend.Auth.Contracts.Requests;
using DakaDiningBackend.Auth.Contracts.Responses;
using DakaDiningBackend.Auth.Services;
using DakaDiningBackend.Entities;
using FastEndpoints;

namespace DakaDiningBackend.Auth.Endpoints;

public class RegisterEndpoint : Endpoint<RegisterRequest, RegisterResponse>
{
    private readonly DakaContext _context;
    private readonly ILogger _logger;
    private readonly IUserService _userService;

    public RegisterEndpoint(DakaContext context, ILogger<RegisterEndpoint> logger, IUserService userService)
    {
        _context = context;
        _logger = logger;
        _userService = userService;
    }

    public override void Configure()
    {
        Post("/auth/register");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
    {
        var existingUser = _context.Users.SingleOrDefault(user => user.Email == req.Email);

        if (existingUser != null)
        {
            _logger.LogInformation($"Tried to register account with email already in use: {req.Email}");
            ThrowError(r => r.Email, "This email is already in use", StatusCodes.Status409Conflict);
        }

        var createdUser = _userService.CreateUserFromRegisterRequest(req);
        var jwtToken = _userService.CreateJwtToken(createdUser);

        var response = new RegisterResponse
        {
            UserId = createdUser.UserId,
            Token = jwtToken
        };

        await SendAsync(response, StatusCodes.Status200OK, ct);
    }
}
