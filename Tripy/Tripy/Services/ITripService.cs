using Tripy.DTO;

namespace Tripy.Services;

public interface ITripService
{
    public Task<Object> GetTrips(int page, int pageSize);
}