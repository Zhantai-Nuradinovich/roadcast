using roadcast.Application.Features.Geo.Models;

namespace roadcast.Application.Features.Geo.Services.Interfaces;

public interface IGeoService
{
    Task<string> UpdateLocationAsync(LocationUpdateDto location);
}
