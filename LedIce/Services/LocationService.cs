using LedIce.Data;
using LedIce.Data.DTO;

using Microsoft.EntityFrameworkCore;

namespace LedIce.Services;

public sealed class LocationService : Service
{
    public LocationService(Context context) : base(context)
    {
    }

    public async Task<Location?> GetFirstLocationAsync()
    {
        var query = from l in Context.Locations
                    select new Location
                    {
                        City = l.City,
                        Description = l.Description,
                        Street = l.Street,
                        Map = l.Map,
                        WorkingHours = l.WorkingHours,
                        WorkingHoursForSchema = l.WorkingHoursForSchema,
                        Email = l.Email,
                        Phone = l.Phone
                    };

        var result = await query
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return result;
    }
}
