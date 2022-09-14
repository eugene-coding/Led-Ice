using LedIce.Data;
using LedIce.Data.DTO;
using LedIce.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace LedIce.Services.Implementations;

internal sealed class LocationService : Service, ILocationService
{
    public LocationService(Context context) : base(context)
    {
    }

    public async Task<LocationDTO?> GetFirstLocationAsync()
    {
        var query = from l in Context.Locations
                    select new LocationDTO
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
