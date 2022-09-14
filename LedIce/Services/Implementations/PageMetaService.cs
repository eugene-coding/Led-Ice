using LedIce.Data;
using LedIce.Data.DTO;
using LedIce.Interfaces;
using LedIce.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace LedIce.Services.Implementations;

internal sealed class PageMetaService : Service, IPageMetaService
{
    public PageMetaService(Context context) : base(context)
    {
    }

    public async Task<PageMetaDTO?> GetPageMetaAsync(ISeoable page)
    {
        var query = from p in Context.PageMetas
                    where p.Seo == page.Seo
                    select new PageMetaDTO
                    {
                        Title = p.Title,
                        Description = p.Description,
                        Keyword = p.Keyword
                    };

        var result = await query
            .AsNoTracking()
            .SingleOrDefaultAsync();

        return result;
    }
}
