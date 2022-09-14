using LedIce.Data.DTO;
using LedIce.Extensions;
using LedIce.Interfaces;
using LedIce.Services.Interfaces;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace LedIce.Pages;

public sealed class IndexModel : PageModel, ISeoable
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IPageMetaService _pageMetaService;
    private readonly ISlideService _slideService;
    private readonly IManagerService _managerService;

    public IndexModel(
        LinkGenerator linkGenerator, 
        IPageMetaService pageMetaService, 
        ISlideService slideService, 
        IManagerService managerService, 
        IStringLocalizer<IndexModel> text)
    {
        _linkGenerator = linkGenerator;
        _pageMetaService = pageMetaService;
        _slideService = slideService;
        _managerService = managerService;

        Text = text;
        PageMeta = default!;
        Slides = default!;
        Managers = default!;
    }

    public PageMetaDTO PageMeta { get; private set; }
    public IEnumerable<SlideDTO> Slides { get; private set; }
    public IEnumerable<ManagerDTO> Managers { get; private set; }
    public IStringLocalizer<IndexModel> Text { get; private init; }
    public string Seo { get; init; } = string.Empty;

    public async Task OnGetAsync()
    {
        PageMeta = await _pageMetaService.GetPageMetaAsync(this) ?? new();
        Slides = await _slideService.GetSlidesAsync();
        Managers = await _managerService.GetManagersAsync();

        InitializeViewData();
    }

    private void InitializeViewData()
    {
        ViewData.SetMeta(PageMeta);
        ViewData["Canonical"] = _linkGenerator.GetPathByPage("/Index");
    }
}
