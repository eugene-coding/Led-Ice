using LedIce.DTO;
using LedIce.Services;

using Microsoft.AspNetCore.Components;

namespace LedIce.Pages.Shared;

public partial class Managers
{
    private IEnumerable<Manager> _managers = Enumerable.Empty<Manager>();

    [Inject]
    private ManagerService Service { get; init; } = default!;

    public IEnumerable<Manager> Items { get; private set; } = Enumerable.Empty<Manager>();

    protected override async Task OnParametersSetAsync()
    {
        _managers = await Service.GetManagersAsync();
    }
}
