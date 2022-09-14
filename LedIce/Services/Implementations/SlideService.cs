using LedIce.Data;
using LedIce.Data.DTO;
using LedIce.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace LedIce.Services.Implementations;

internal sealed class SlideService : Service, ISlideService
{
    public SlideService(Context context) : base(context)
    {
    }

    public async Task<IEnumerable<SlideDTO>> GetSlidesAsync()
    {
        var query = from s in Context.Slides
                    where s.Enabled
                    orderby s.SortOrder
                    select new SlideDTO
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
