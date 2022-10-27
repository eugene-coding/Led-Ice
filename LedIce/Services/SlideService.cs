using LedIce.Data;
using LedIce.Data.DTO;

using Microsoft.EntityFrameworkCore;

namespace LedIce.Services;

public sealed class SlideService : Service
{
    public SlideService(Context context) : base(context)
    {
    }

    public async Task<IEnumerable<Slide>> GetSlidesAsync()
    {
        var query = from s in Context.Slides
                    where s.Enabled
                    orderby s.SortOrder
                    select new Slide
                    {
                        Title = s.Title,
                        Description = s.Description,
                        BackgroundImage = s.BackgroundImage,
                        OverlayColor = s.OverlayColor
                    };

        var result = await query
            .AsNoTracking()
            .ToListAsync();

        return result;
    }
}
