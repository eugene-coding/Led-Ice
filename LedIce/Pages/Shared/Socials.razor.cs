using LedIce.DTO;
using LedIce.Services;

using Microsoft.AspNetCore.Components;

namespace LedIce.Pages.Shared;

public partial class Socials
{
    private IEnumerable<Social> _socials = Enumerable.Empty<Social>();

    [Inject]
    private SocialService Service { get; init; } = default!;

    protected override async Task OnParametersSetAsync()
    {
        _socials = await Service.GetSocialsAsync();
    }
}
