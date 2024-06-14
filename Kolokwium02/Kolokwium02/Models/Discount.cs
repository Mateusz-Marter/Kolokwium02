using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium02.Models;

public partial class Discount
{
    [Key]
    public int IdDiscount { get; set; }
    [Required]
    public int Value { get; set; }
    [Required]
    [ForeignKey(nameof(IdSubscription))]
    public int IdSubscription { get; set; }
    [Required]
    public DateOnly DateFrom { get; set; }
    [Required]
    public DateOnly DateTo { get; set; }
    public virtual Subscription IdSubscriptionNavigation { get; set; } = null!;
}
