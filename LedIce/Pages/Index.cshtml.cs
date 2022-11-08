using LedIce.DTO;
using LedIce.Extensions;
using LedIce.Interfaces;
using LedIce.Services;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace LedIce.Pages;

public sealed class IndexModel : PageModel, ISeoable
{
    private readonly LinkGenerator _linkGenerator;
    private readonly PageMetaService _pageMetaService;
    private readonly SlideService _slideService;

    public IndexModel(
        LinkGenerator linkGenerator,
        PageMetaService pageMetaService,
        SlideService slideService,
        IStringLocalizer<IndexModel> text)
    {
        _linkGenerator = linkGenerator;
        _pageMetaService = pageMetaService;
        _slideService = slideService;

        Text = text;
        PageMeta = default!;
        Slides = default!;
    }

    public PageMeta PageMeta { get; private set; }
    public IEnumerable<Slide> Slides { get; private set; }
    public IStringLocalizer<IndexModel> Text { get; private init; }
    public string Seo { get; init; } = string.Empty;

    public async Task OnGetAsync()
    {
        PageMeta = await _pageMetaService.GetPageMetaAsync(this) ?? new();
        Slides = await _slideService.GetSlidesAsync();

        InitializeViewData();
    }

    private void InitializeViewData()
    {
        ViewData.SetMeta(PageMeta);
        ViewData["Canonical"] = _linkGenerator.GetPathByPage("/Index");
    }
}
