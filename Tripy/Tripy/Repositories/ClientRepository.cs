using Microsoft.EntityFrameworkCore;
using Tripy.Context;

namespace Tripy.Repositories;

public class ClientRepository : IClientRepository
{
    public async Task<int> DeleteClient(int id)
    {
        var mc = new MasterContext();
        var client = await mc.Clients.FirstOrDefaultAsync(c => c.IdClient == id);
        if (client == null)
        {
            return -1;
        }
        
        if (mc.ClientTrips.Any(c => c.IdClient == id))
        {
            return 0;
        }

        mc.Clients.Remove(client);
        mc.SaveChangesAsync();
        return 1;
    }
}