using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace Kolokwium02.Context;

public class SubContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;Trust Server Certificate=True");
    }
    
    public DbSet<Client> _Clients { get; set; }
    public DbSet<Discount> _Discounts { get; set; }
    public DbSet<Payment> _Payments { get; set; }
    public DbSet<Sale> _Sales { get; set; }
    public DbSet<Subscription> _Subscriptions { get; set; }
    
}