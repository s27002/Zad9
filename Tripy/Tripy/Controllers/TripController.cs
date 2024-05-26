using Microsoft.AspNetCore.Mvc;
using Tripy.DTO;
using Tripy.Services;

namespace Tripy.Controllers;

[ApiController]
[Route("api/[Controller]")]

public class TripController : ControllerBase
{
    private ITripService _tripService;
    private IClientTripService _clientTripService;
    
    public TripController(ITripService tripService, IClientTripService clientTripService)
    {
        _tripService = tripService;
        _clientTripService = clientTripService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTrips(int page, int pageSize = 10)
    {
        var trips = await _tripService.GetTrips(page, pageSize);
        return Ok(trips);
    }

    [HttpPost("{TripId}/clients")]
    public async Task<IActionResult> SignUp(NewClientDto client, int TripId)
    {
        int check = await _clientTripService.SignUp(client, TripId);
        if (check == -1)
        {
            return BadRequest("Taki klient nie istnieje");
        }
        if (check == 0)
        {
            return BadRequest("Taka wycieczka nie istnieje");
        }
        if (check == 1)
        {
            return BadRequest("Klient jest już przypisany do tej wycieczki");
        }
        if (check == 2)
        {
            return BadRequest("Ta wycieczka już się zakończyła");
        }
        return Ok("Dodano pomyślnie"); 
    }
}