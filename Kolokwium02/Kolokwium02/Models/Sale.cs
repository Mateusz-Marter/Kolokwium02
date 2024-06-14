using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium02.Models;

public partial class Sale
{
    [Key]
    public int IdSale { get; set; }
    [Required]
    public int IdClient { get; set; }
    [Required]
    public int IdSubscription { get; set; }
    [Required]
    public DateOnly CreatedAt { get; set; }
    [Required]
    public virtual Client IdClientNavigation { get; set; } = null!;
    [Required]
    public virtual Subscription IdSubscriptionNavigation { get; set; } = null!;
}
