using System.ComponentModel.DataAnnotations;

namespace LedIce.Models;

public class Meta
{
    [Key]
    public string Seo { get; set; } = string.Empty;

    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public string? Keywords { get; set; }
}
