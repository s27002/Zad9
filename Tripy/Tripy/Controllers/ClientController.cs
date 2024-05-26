using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Tripy.Services;

namespace Tripy.Controllers;

[ApiController]
[Route("api/[Controller]")]

public class ClientController : ControllerBase
{
    private IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }
    
    
    [HttpDelete("{ClientId}")]
    public async Task<IActionResult> DeleteClient(int ClientId)
    {
        var check = await _clientService.DeleteClient(ClientId);
        if (check == -1)
        {
            return BadRequest("Klient o takim ID nie istnieje");
        }
        if (check == 0)
        {
            return BadRequest("Klient o takim ID ma przypisane wycieczki");
        }
        return Ok("Klient został pomyślnie usunięty");
    }
}