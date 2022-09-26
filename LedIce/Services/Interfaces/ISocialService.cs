using LedIce.Data.DTO;

namespace LedIce.Services.Interfaces;

public interface ISocialService
{
    Task<IEnumerable<SocialDTO?>> GetSocialsAsync();
}
