using Kolokwium02.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium02.Controllers;

public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetClientWithSubscription(int id)
    {
        if (!await _clientService.ClientExists(id))
        {
            return NotFound("Client does not exist");
        }

        var data = await _clientService.GetClientWithSubcription(id);

        return Ok(data);
    }
}