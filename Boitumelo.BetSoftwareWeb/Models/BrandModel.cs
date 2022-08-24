using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareWeb.Models
{
    public class BrandModel
    {
        public int Id
        {
            get; set;
        }
        [Required]
        [MaxLength(100)]
        public string BrandDescription
        {
            get; set;
        }
    }
}
