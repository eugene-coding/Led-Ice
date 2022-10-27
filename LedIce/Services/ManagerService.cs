using LedIce.Data;
using LedIce.Data.DTO;

using Microsoft.EntityFrameworkCore;

namespace LedIce.Services;

public sealed class ManagerService : Service
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
