using LedIce.DTO;
using LedIce.Extensions;
using LedIce.Interfaces;
using LedIce.Services;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace LedIce.Pages;

public sealed class ContactsModel : PageModel, ISeoable
{
    private readonly LinkGenerator _linkGenerator;
    private readonly PageMetaService _pageMetaService;
    private readonly LocationService _locationService;
    private readonly SocialService _socialService;

    public ContactsModel(
        LinkGenerator linkGenerator, 
        PageMetaService pageMetaService, 
        LocationService service,
        SocialService socialService,
        IStringLocalizer<ContactsModel> text)
    {
        _linkGenerator = linkGenerator;
        _pageMetaService = pageMetaService;
        _locationService = service;
        _socialService = socialService;

        Text = text;
        PageMeta = default!;
        Location = default!;
        Socials = default!;
    }

    public PageMeta PageMeta { get; private set; }
    public Location Location { get; private set; }
    public IEnumerable<Social?> Socials { get; private set; }
    public IStringLocalizer<ContactsModel> Text { get; private init; }
    public string Seo { get; init; } = "contacts";

    public async Task OnGetAsync()
    {
        PageMeta = await _pageMetaService.GetPageMetaAsync(this) ?? new();
        Location = await _locationService.GetFirstLocationAsync() ?? new();
        Socials = await _socialService.GetSocialsAsync() ?? Enumerable.Empty<Social>();

        InitializeViewData();
    }

    private void InitializeViewData()
    {
        ViewData.SetMeta(PageMeta);
        ViewData["Canonical"] = _linkGenerator.GetPathByPage("/Contacts");
    }
}
