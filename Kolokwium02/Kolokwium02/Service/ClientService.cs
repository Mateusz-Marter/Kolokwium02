

using Kolokwium02.Context;
using Kolokwium02.DTO;
using Kolokwium02.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium02.Service;

public interface IClientService
{
    public Task<bool> ClientExists(int id);
    public Task<ClientDto> GetClientWithSubcription(int id);
}

public class ClientService : IClientService
{
    private readonly SubContext _context;

    public ClientService(SubContext context)
    {
        _context = context;
    }
    
    
    public async Task<bool> ClientExists(int id)
    {
        var client = await _context.Clients.CountAsync(c => c.IdClient == id); // zlicza rekordy o podanym id
        return client > 0;
    }

    public async Task<ClientDto> GetClientWithSubcription(int id)
    {
        var client = await _context.Clients
            .Include(c => c.Sales)
            .ThenInclude(s => s.IdSubscriptionNavigation) 
            .Include(c => c.Payments) 
            .Where(c => c.IdClient == id) 
            .FirstOrDefaultAsync(); 
        if (client == null)
        {
            return null;
        }
        
        var clientDto = new ClientDto
        {
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            Phone = client.Phone,
            Subscriptions = client.Sales.Select(s => new SubscriptionDto
            {
                IdSubscription = s.IdSubscriptionNavigation.IdSubscription,
                Name = s.IdSubscriptionNavigation.Name,
                TotalPaidAmount = client.Payments
                    .Where(p => p.IdSubscription == s.IdSubscription)
                    .Sum(p => s.IdSubscriptionNavigation.Price)
            }).ToList()
        };

        return clientDto;

    }
}