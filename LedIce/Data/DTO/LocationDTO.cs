namespace LedIce.Data.DTO;

public class LocationDTO
{
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Map { get; set; }
    public string WorkingHours { get; set; } = string.Empty;
    public string WorkingHoursForSchema { get; set; } = string.Empty;
}
