using Microsoft.EntityFrameworkCore;
using Tripy.Context;
using Tripy.DTO;
using Tripy.Models;

namespace Tripy.Repositories;

public class ClientTripRepository : IClientTripRepository
{
    public async Task<int> SignUp(NewClientDto client, int TripId)
    {
        var mc = new MasterContext();
        if (!mc.Clients.Any(c => c.Pesel.Equals(client.Pesel)))
        {
            return -1;
        }
        if (!mc.Trips.Any(t => t.IdTrip == TripId))
        {
            return 0;
        }
        var newClient = await mc.Clients.FirstOrDefaultAsync(c => c.Pesel.Equals(client.Pesel));
        if (mc.ClientTrips.Any(ct => ct.IdClient == newClient.IdClient && ct.IdTrip == TripId))
        {
            return 1;
        }
        if ((await mc.Trips.FirstOrDefaultAsync(t => t.IdTrip == TripId)).DateFrom < DateTime.Now)
        {
            return 2;
        }

        var newTrip = await mc.Trips.FirstOrDefaultAsync(t => t.IdTrip == TripId);
        var cl = new ClientTrip
        {
            IdClient = newClient.IdClient,
            IdClientNavigation = newClient,
            IdTrip = TripId,
            IdTripNavigation = newTrip,
            PaymentDate = client.PaymentDate,
            RegisteredAt = DateTime.Now
        };
        await mc.ClientTrips.AddAsync(cl);
        await mc.SaveChangesAsync();
        return 3;
    }
}