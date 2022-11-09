using LedIce.DTO;
using LedIce.Extensions;
using LedIce.Services;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace LedIce.Pages;

public sealed class IndexModel : PageModel
{
    public static readonly string Seo = string.Empty;

    private readonly LinkGenerator _linkGenerator;
    private readonly MetaService _metaService;
    private readonly SlideService _slideService;

    public IndexModel(
        LinkGenerator linkGenerator,
        MetaService metaService,
        SlideService slideService,
        IStringLocalizer<IndexModel> text)
    {
        _linkGenerator = linkGenerator;
        _metaService = metaService;
        _slideService = slideService;
        Text = text;
    }

    public Meta Meta { get; private set; } = default!;
    public IEnumerable<Slide> Slides { get; private set; } = Enumerable.Empty<Slide>();
    public IStringLocalizer<IndexModel> Text { get; private init; }

    public async Task OnGetAsync()
    {
        Meta = await _metaService.GetMetaAsync(Seo);
        Slides = await _slideService.GetSlidesAsync();

        InitializeViewData();
    }

    private void InitializeViewData()
    {
        ViewData.SetMeta(Meta);
        ViewData["Canonical"] = _linkGenerator.GetPathByPage("/Index");
    }
}
