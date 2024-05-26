using Tripy.DTO;

namespace Tripy.Services;

public interface IClientTripService
{
    public Task<int> SignUp(NewClientDto client, int TripId);
}