using Tripy.DTO;
using Tripy.Repositories;

namespace Tripy.Services;

public class ClientTripService : IClientTripService
{
    private IClientTripRepository _clientTripRepository;

    public ClientTripService(IClientTripRepository clientTripRepository)
    {
        _clientTripRepository = clientTripRepository;
    }
    
    public async Task<int> SignUp(NewClientDto client, int TripId)
    {
        return await _clientTripRepository.SignUp(client, TripId);
    }
}