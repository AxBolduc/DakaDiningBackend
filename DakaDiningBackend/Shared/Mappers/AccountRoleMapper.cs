using DakaDiningBackend.Shared.Models;

namespace DakaDiningBackend.Shared.Mappers;

public class AccountRoleMapper
{
    public static ICollection<string> MapToStrings(ICollection<AccountRole> roles)
    {
        List<string> stringRoles = new List<string>();
        foreach (var role in roles)
        {
            stringRoles.Add(MapToString(role));
        }

        return stringRoles;
    }
    public static string MapToString(AccountRole role)
    {
        switch (role)
        {
            case AccountRole.Basic:
                return "Basic";
            case AccountRole.Admin :
                return "Admin";
            default:
                throw new Exception("Could not map Account role to string representation");
        }
    }

    public static AccountRole MapFromString(string role)
    {
        switch (role.ToLower())
        {
            case "basic":
                return AccountRole.Basic;
            case "admin":
                return AccountRole.Admin;
            default:
                throw new Exception($"Could not map String '{role}' to valid AccountRole");
        }
    }
}
