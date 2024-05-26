using Microsoft.EntityFrameworkCore;
using Tripy.Context;
using Tripy.DTO;

namespace Tripy.Repositories;

public class TripRepository : ITripRepository
{

    public async Task<Object> GetTrips(int page, int pageSize)
    {
        var mc = new MasterContext();
        int all = (int)Math.Ceiling(await mc.Trips.CountAsync() / (double)pageSize);
        var trips = await mc.Trips.Include(t => t.IdCountries)
            .Include(t => t.ClientTrips).ThenInclude(ct => ct.IdClientNavigation)
            .OrderByDescending(t => t.DateFrom).Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
        
        return new
        {
            pageNum = page,
            pageSize = pageSize,
            allPages = all,
            trips = trips.Select(td => new TripDto
            {
                Name = td.Name,
                Description = td.Description,
                DateFrom = td.DateFrom,
                DateTo = td.DateTo,
                MaxPeople = td.MaxPeople,
                Countries = td.IdCountries.Select(c => new CountryDto
                {
                    Name = c.Name
                }).ToList(),
                Clients = td.ClientTrips.Select(ctd => new ClientTripDto
                {
                    FirstName = ctd.IdClientNavigation.FirstName,
                    LastName = ctd.IdClientNavigation.LastName,
                }).ToList()
            }).ToList()
        };
    }
}
