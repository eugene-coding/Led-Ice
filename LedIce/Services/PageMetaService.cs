using LedIce.Data;
using LedIce.Data.DTO;
using LedIce.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace LedIce.Services;

public sealed class PageMetaService : Service
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
