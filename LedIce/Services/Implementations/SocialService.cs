using LedIce.Data;
using LedIce.Data.DTO;
using LedIce.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace LedIce.Services.Implementations;

internal sealed class SocialService : Service, ISocialService
{
    public SocialService(Context context) : base(context)
    {
    }

    public async Task<IEnumerable<SocialDTO?>> GetSocialsAsync()
    {
        var query = from s in Context.Socials
                    where s.Enabled
                    orderby s.SortOrder
                    select new SocialDTO
                    {
                        Icon = s.Icon,
                        Link = s.Link
                    };

        var result = await query
            .AsNoTracking()
            .ToListAsync();

        return result;
    }
}
