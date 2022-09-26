using LedIce.Data.DTO;
using LedIce.Extensions;
using LedIce.Interfaces;
using LedIce.Services.Interfaces;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace LedIce.Pages;

public sealed class ContactsModel : PageModel, ISeoable
{
    private readonly LinkGenerator _linkGenerator;
    private readonly IPageMetaService _pageMetaService;
    private readonly ILocationService _locationService;
    private readonly ISocialService _socialService;

    public ContactsModel(
        LinkGenerator linkGenerator, 
        IPageMetaService pageMetaService, 
        ILocationService service,
        ISocialService socialService,
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

    public PageMetaDTO PageMeta { get; private set; }
    public LocationDTO Location { get; private set; }
    public IEnumerable<SocialDTO?> Socials { get; private set; }
    public IStringLocalizer<ContactsModel> Text { get; private init; }
    public string Seo { get; init; } = "contacts";

    public async Task OnGetAsync()
    {
        PageMeta = await _pageMetaService.GetPageMetaAsync(this) ?? new();
        Location = await _locationService.GetFirstLocationAsync() ?? new();
        Socials = await _socialService.GetSocialsAsync() ?? Enumerable.Empty<SocialDTO>();

        InitializeViewData();
    }

    private void InitializeViewData()
    {
        ViewData.SetMeta(PageMeta);
        ViewData["Canonical"] = _linkGenerator.GetPathByPage("/Contacts");
    }
}
