using DakaDiningBackend.Auth.Contracts.Requests;
using DakaDiningBackend.Entities;
using DakaDiningBackend.Shared.Mappers;
using DakaDiningBackend.Shared.Models;
using FastEndpoints.Security;

namespace DakaDiningBackend.Auth.Services;

public class UserService : IUserService
{
    private readonly DakaContext _context;
    private readonly ILogger _logger;

    public UserService(DakaContext context, ILogger<UserService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public string CreateJwtToken(UserEntity user)
    {
        return JWTBearer.CreateToken(
            signingKey: "THIS_IS_A_SECRET",
            expireAt: DateTime.UtcNow.AddDays(1),
            privileges: u =>
            {
                u.Roles.Add(user.Role);
                u.Permissions.AddRange(new[] { "OfferSwipes", "RequestSwipes", "FillRequests", "PurchaseOffers" });
                u.Claims.Add(new("Email", user.Email));
                u["UserId"] = user.UserId;
            }
        );
    }

    public UserEntity CreateUserFromRegisterRequest(RegisterRequest registerRequest)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password);

        var createdUser = new UserEntity
        {
            UserId = Guid.NewGuid().ToString(),
            Email = registerRequest.Email,
            FirstName = registerRequest.FirstName,
            LastName = registerRequest.LastName,
            Password = passwordHash,
            MealsOffered = 0,
            MealSwipes = registerRequest.MealSwipes ?? 0,
            Plan = registerRequest.Plan ?? MealPlanMapper.MapToString(MealPlan.BasicFourteen),
            Role = AccountRoleMapper.MapToString(AccountRole.Basic)
        };

        try
        {
            _context.Users.Add(createdUser);
            _context.SaveChanges();
        }
        catch (Exception err)
        {
            _logger.LogError(err.ToString());
            throw;
        }

        return createdUser;
    }
}
