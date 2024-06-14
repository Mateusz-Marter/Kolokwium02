using Kolokwium02.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium02.Controllers;

public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpPut]
    public async Task<IActionResult> GetSubsciptionPayment(int IdClient, int IdSubcripton, decimal Payment)
    {
        return Ok();
    }
}