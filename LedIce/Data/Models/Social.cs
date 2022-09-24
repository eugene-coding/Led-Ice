using System.ComponentModel.DataAnnotations;

namespace LedIce.Data.Models;

public class Social
{
    public int Id { get; set; }

    public Uri Link { get; set; } = default!;

    [MaxLength(50)]
    public string Icon { get; set; } = string.Empty;

    public int SortOrder { get; set; }
    public bool Enabled { get; set; }
}
