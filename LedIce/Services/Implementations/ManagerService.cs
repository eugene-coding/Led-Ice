using LedIce.Data;
using LedIce.Data.DTO;
using LedIce.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace LedIce.Services.Implementations;

internal sealed class ManagerService : Service, IManagerService
{
    public ManagerService(Context context) : base(context)
    {
    }

    public async Task<IEnumerable<ManagerDTO>> GetManagersAsync()
    {
        var query = from m in Context.Managers
                    where m.Enabled
                    orderby m.SortOrder
                    select new ManagerDTO
                    {
                        City = m.City,
                        Name = m.Name,
                        Phone = m.Phone,
                        Email = m.Email
                    };

        var result = await query
            .AsNoTracking()
            .ToListAsync();

        return result;
    }
}
