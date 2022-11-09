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
    private readonly MetaService _metaService;
    private readonly LocationService _locationService;
    
    public ContactsModel(
        LinkGenerator linkGenerator, 
        MetaService metaService, 
        LocationService service,
        IStringLocalizer<ContactsModel> text)
    {
        _linkGenerator = linkGenerator;
        _metaService = metaService;
        _locationService = service;
  
        Text = text;
        Meta = default!;
        Location = default!;
    }

    public Meta Meta { get; private set; }
    public Location Location { get; private set; }
    public IStringLocalizer<ContactsModel> Text { get; private init; }
    public string Seo { get; init; } = "contacts";

    public async Task OnGetAsync()
    {
        Meta = await _metaService.GetMetaAsync(this) ?? new();
        Location = await _locationService.GetFirstLocationAsync() ?? new();

        InitializeViewData();
    }

    private void InitializeViewData()
    {
        ViewData.SetMeta(Meta);
        ViewData["Canonical"] = _linkGenerator.GetPathByPage("/Contacts");
    }
}
