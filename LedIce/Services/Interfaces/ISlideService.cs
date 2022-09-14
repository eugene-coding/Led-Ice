using LedIce.Data.DTO;

namespace LedIce.Services.Interfaces;

public interface ISlideService
{
    Task<IEnumerable<SlideDTO>> GetSlidesAsync();
}
