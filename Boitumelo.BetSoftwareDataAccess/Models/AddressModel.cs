using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareDataAccess.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        [MaxLength(250)]
        public string? Address1 { get; set; }
        [MaxLength(250)]
        public string? Address2 { get; set; }
        [MaxLength(250)]
        public string? Address3 { get; set; }
        [MaxLength(100)]
        public string? Country { get; set; }
        [MaxLength(100)]
        public string? City { get; set; }
        [MaxLength(50)]
        public string? Town { get; set; }
        [MaxLength(20)]
        public string? AreaCode { get; set; }

    }
}