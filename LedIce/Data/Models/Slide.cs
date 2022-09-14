using System.ComponentModel.DataAnnotations;

namespace LedIce.Data.Models;

public class Slide
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public Uri BackgroundImage { get; set; } = default!;

    [MaxLength(150)]
    public string OverlayColor { get; set; } = string.Empty;

    public bool Enabled { get; set; }
    public int SortOrder { get; set; }
}
