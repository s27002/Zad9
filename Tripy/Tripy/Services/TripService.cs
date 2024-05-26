using Tripy.DTO;
using Tripy.Repositories;

namespace Tripy.Services;

public class TripService : ITripService
{
    private ITripRepository _tripRepository;
    
    public TripService(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }
    
    public async Task<Object> GetTrips(int page, int pageSize)
    {
        return await _tripRepository.GetTrips(page, pageSize);
    }
}