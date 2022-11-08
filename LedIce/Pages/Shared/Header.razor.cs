using Microsoft.AspNetCore.Components;

namespace LedIce.Pages.Shared;

public partial class Header
{
    [Parameter]
    public bool Fixed { get; init; }

    private string? Class => Fixed ? "header_fixed" : null;
}
