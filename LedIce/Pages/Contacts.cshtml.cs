using LedIce.DTO;
using LedIce.Extensions;
using LedIce.Services;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace LedIce.Pages;

public sealed class ContactsModel : PageModel
{
    public const string Seo = "contacts";

    private readonly LinkGenerator _linkGenerator;
    private readonly MetaService _metaService;
    private readonly LocationService _locationService;
    
    public ContactsModel(
        LinkGenerator linkGenerator, 
        MetaService metaService, 
        LocationService locationService,
        IStringLocalizer<ContactsModel> text)
    {
        _linkGenerator = linkGenerator;
        _metaService = metaService;
        _locationService = locationService;
  
        Text = text;
    }

    public Meta Meta { get; private set; } = default!;
    public Location Location { get; private set; } = default!;
    public IStringLocalizer<ContactsModel> Text { get; private init; }

    public async Task OnGetAsync()
    {
        Meta = await _metaService.GetMetaAsync(Seo);
        Location = await _locationService.GetFirstLocationAsync();

        InitializeViewData();
    }

    private void InitializeViewData()
    {
        ViewData.SetMeta(Meta);
        ViewData["Canonical"] = _linkGenerator.GetPathByPage("/Contacts");
    }
}
