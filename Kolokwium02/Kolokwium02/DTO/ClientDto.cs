using WebApplication4.Models;

namespace WebApplication4.DTO;

public class ClientDto
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public List<SubscriptionDto> Subscriptions { get; set; }
}