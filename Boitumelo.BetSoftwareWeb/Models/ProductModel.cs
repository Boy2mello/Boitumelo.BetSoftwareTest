using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareWeb.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }
    }
}