using LedIce.Data.DTO;

namespace LedIce.Services.Interfaces;

public interface ILocationService
{
    Task<LocationDTO?> GetFirstLocationAsync();
}
