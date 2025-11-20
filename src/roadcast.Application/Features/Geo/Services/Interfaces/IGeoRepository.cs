using roadcast.Domain.Entities.Geo;

namespace roadcast.Application.Features.Geo.Services.Interfaces;

public interface IGeoRepository
{
    Task<GeoLocation?> GetAsync(string userId);
    Task UpsertAsync(GeoLocation location);
}
