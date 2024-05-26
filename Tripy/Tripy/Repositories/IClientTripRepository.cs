using Tripy.DTO;

namespace Tripy.Repositories;

public interface IClientTripRepository
{
    public Task<int> SignUp(NewClientDto client, int TripId);
}