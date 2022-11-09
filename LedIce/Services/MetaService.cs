using LedIce.Data;
using LedIce.DTO;

using Microsoft.EntityFrameworkCore;

namespace LedIce.Services;

public sealed class MetaService : Service
{
    public MetaService(Context context) : base(context)
    {
    }

    public async Task<Meta> GetMetaAsync(string seo)
    {
        var query = from p in Context.Metas
                    where p.Seo == seo
                    select new Meta
                    {
                        Title = p.Title,
                        Description = p.Description,
                        Keywords = p.Keywords
                    };

        var result = await query
            .AsNoTracking()
            .SingleOrDefaultAsync();

        return result ?? new();
    }
}
