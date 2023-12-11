using DakaDiningBackend.Shared.Mappers;
using DakaDiningBackend.Shared.Models;

namespace DakaDiningBackend.Shared;

public static class Constants
{
    public static readonly string[] PublicEndpointsAllowedRoles =
        AccountRoleMapper.MapToStrings(new[] { AccountRole.Basic, AccountRole.Admin }).ToArray();
}
