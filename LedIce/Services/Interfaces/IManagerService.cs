using LedIce.Data.DTO;

namespace LedIce.Services.Interfaces;

public interface IManagerService
{
    Task<IEnumerable<ManagerDTO>> GetManagersAsync();
}
