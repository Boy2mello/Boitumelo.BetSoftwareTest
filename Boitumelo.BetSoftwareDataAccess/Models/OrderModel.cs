using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareDataAccess.Models;
public class OrderModel
{
    public int Id { get; set; }
    public int ShippingMethodId { get; set; }
    public int SalesPersonId { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
}
