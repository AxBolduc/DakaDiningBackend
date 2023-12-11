using System.ComponentModel.DataAnnotations;

namespace DakaDiningBackend.Entities;

public class RequestEntity
{
    public string Id { get; set; }

    public string RequestedById { get; set; }
    public UserEntity RequestedBy { get; set; }

    public float Price { get; set; }

    public DateTime RequestedAt { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public bool Filled { get; set; }

    public string? FilledById { get; set; }
    public UserEntity? FilledBy { get; set; }

    public DateTime? FilledAt { get; set; }

}
