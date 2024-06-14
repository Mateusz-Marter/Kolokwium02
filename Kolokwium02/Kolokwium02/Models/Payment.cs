using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models;

public partial class Payment
{
    [Key]
    public int IdPayment { get; set; }
    [Required]
    public DateOnly Date { get; set; }
    [Required]
    public int IdClient { get; set; }
    [Required]
    [ForeignKey(nameof(IdSubscription))]
    public int IdSubscription { get; set; }
    [Required]
    public virtual Client IdClientNavigation { get; set; } = null!;
    [Required]
    public virtual Subscription IdSubscriptionNavigation { get; set; } = null!;
}
