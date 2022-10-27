using System.ComponentModel.DataAnnotations;

namespace LedIce.Models;

public class Manager
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string City { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Phone { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;

    public int SortOrder { get; set; }
    public bool Enabled { get; set; }
}
