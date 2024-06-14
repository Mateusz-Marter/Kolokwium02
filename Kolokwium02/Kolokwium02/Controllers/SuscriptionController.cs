using Kolokwium02.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium02.Controllers;

public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;
    private readonly IClientService _clientService;

    public SubscriptionController(ISubscriptionService subscriptionService, IClientService clientService)
    {
        _subscriptionService = subscriptionService;
        _clientService = clientService;
    }

    [HttpPut]
    public async Task<IActionResult> GetSubsciptionPayment(int IdClient, int IdSubcripton, decimal Payment)
    {
        
        if (!await _clientService.ClientExists(IdClient))
        {
            return NotFound("no found client");
        }
        =
        if (!await _subscriptionService.SubscriptionExists(IdSubcripton))
        {
            return NotFound("no found subscription");
        }
        =
        if (!await _subscriptionService.SubscriptionActives(IdSubcripton))
        {
            return BadRequest("Subscription is not active");
        }
        
        if (!await _subscriptionService.IsSubscriptionPaid(IdSubcripton))
        {
            return BadRequest("subscription is already active");
        }
        
        
        return Ok();
    }
}