using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium02.Models;

public partial class Client
{
    [Key]
    public int IdClient { get; set; }
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; } = null!;
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; } = null!;
    [MaxLength(100)]
    [Required]
    public string Email { get; set; } = null!;
    [MaxLength(100)]
    public string? Phone { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
