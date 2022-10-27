namespace LedIce.Data.DTO;

public class Slide
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Uri BackgroundImage { get; set; } = default!;
    public string OverlayColor { get; set; } = string.Empty;
}
