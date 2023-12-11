using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DakaDiningBackend.Entities;

public class SessionEntity
{
    [Key]
    public string SessionId { get; set; }

    public string UserId { get; set; }
    public UserEntity? User { get; set; }
}
