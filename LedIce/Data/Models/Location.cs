using System.ComponentModel.DataAnnotations;

namespace LedIce.Models;

public class Location
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string City { get; set; } = string.Empty;

    [MaxLength(150)]
    public string Street { get; set; } = string.Empty;

    public string? Description { get; set; }

    [MaxLength(50)]
    public string Phone { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(50)]
    public string WorkingHours { get; set; } = string.Empty;

    [MaxLength(50)]
    public string WorkingHoursForSchema { get; set; } = string.Empty;

    public string? Map { get; set; }
}
