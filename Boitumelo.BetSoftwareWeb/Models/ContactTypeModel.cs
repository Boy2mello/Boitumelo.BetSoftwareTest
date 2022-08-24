using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareWeb.Models
{
    public class ContactTypeModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string ContactType { get; set; }
    }
}