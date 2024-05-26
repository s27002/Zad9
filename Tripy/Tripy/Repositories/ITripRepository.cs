using Tripy.DTO;

namespace Tripy.Repositories;

public interface ITripRepository
{
    public Task<Object> GetTrips(int page, int pageSize);
}