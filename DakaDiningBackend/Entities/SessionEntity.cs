using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DakaDiningBackend.Entities;

public class SessionEntity
{
    [Key]
    public required string SessionId { get; set; }

    public required string UserId { get; set; }
    public UserEntity? User { get; set; } = null!;
}
