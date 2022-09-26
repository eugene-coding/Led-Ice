using System.ComponentModel.DataAnnotations;

namespace LedIce.Data.Models;

public class Social
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    [MaxLength(50)]
    public string IconClass { get; set; } = string.Empty;

    public Uri Link { get; set; } = default!;

    public int SortOrder { get; set; }
    public bool Enabled { get; set; }
}
