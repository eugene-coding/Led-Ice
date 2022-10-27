using System.ComponentModel.DataAnnotations;

namespace LedIce.Models;

public class PageMeta
{
    [Key]
    public string Seo { get; set; } = string.Empty;

    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public string? Keyword { get; set; }
}
