namespace Kolokwium02.Service;


public interface ISubscriptionService
{
    Task<bool> SubscriptionExists(int idSubcripton);
    Task<bool> SubscriptionActives(int idSubcripton);
    Task<bool> IsSubscriptionPaid(int idSubcripton);
}

public class SubscriptionService
{
    
}