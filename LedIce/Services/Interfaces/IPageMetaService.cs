using LedIce.Data.DTO;
using LedIce.Interfaces;

namespace LedIce.Services.Interfaces;

public interface IPageMetaService
{
    Task<PageMetaDTO?> GetPageMetaAsync(ISeoable page);
}
