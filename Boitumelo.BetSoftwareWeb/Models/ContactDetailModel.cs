using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareWeb.Models
{
    public class ContactDetailModel
    {
        public int Id
        {
            get; set;
        }
        public int UserID
        {
            get; set;
        }
        public int ContactTypeId
        {
            get; set;
        }
        [Required]
        [MaxLength(250)]
        public string Contact
        {
            get; set;
        }
    }
}
