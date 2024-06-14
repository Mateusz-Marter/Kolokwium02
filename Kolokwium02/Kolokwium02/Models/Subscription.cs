using System.ComponentModel.DataAnnotations;

namespace Kolokwium02.Models;

public partial class Subscription
{
    [Key]
    public int IdSubscription { get; set; }
    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int RenewalPeriod { get; set; }
    [Required]
    public DateOnly EndTime { get; set; }
    [Required]
    public decimal Price { get; set; }
    
    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
