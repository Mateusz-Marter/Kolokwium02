namespace Kolokwium02.DTO;

public class SubscriptionDto
{
    public int IdSubscription { get; set; }
    public string Name { get; set; } = null!;
    public decimal TotalPaidAmount { get; set; }
}