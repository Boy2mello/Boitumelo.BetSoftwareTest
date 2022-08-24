using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareDataAccess.Models;
public class PaymentModel
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int PaymentId { get; set; }
    public decimal PaymentAmount { get; set; }
    public DateTime PaymentDate { get; set; }
    [Required]
    [MaxLength(10)]
    public string CardNumber { get; set; }
    [Required]
    public DateOnly CardExpiryDate { get; set; }
    [Required]
    [MaxLength(100)]
    public string? CardHolderName { get; set; }
}
