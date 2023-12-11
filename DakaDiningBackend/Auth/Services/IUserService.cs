using DakaDiningBackend.Auth.Contracts.Requests;
using DakaDiningBackend.Entities;

namespace DakaDiningBackend.Auth.Services;

public interface IUserService
{
   UserEntity CreateUserFromRegisterRequest(RegisterRequest registerRequest);

   String CreateJwtToken(UserEntity user);
}
