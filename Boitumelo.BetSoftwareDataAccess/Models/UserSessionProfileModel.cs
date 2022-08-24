using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Boitumelo.BetSoftwareDataAccess.Models.ShoppingCartModel;

namespace Boitumelo.BetSoftwareDataAccess.Models;


public class UserSessionProfileModel
{
    public int ProfileId { get; set; }
    public string? Title { get; set; }
    public string? Name { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }    
    public int ContactId { get; set; }
    public string? Email { get; set; }
    public string? Subject { get; set; }
    public string? TenantId { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public ShoppingCartModel? ShoppingCart { get; set; }
}

public class ShoppingCartModel
{
    public int ShoppingCartId { get; set; }
    public int UserId { get; set; }
    public int Id { get; set; }
    public bool IsOrdered { get; set; }
    public string? OrderId { get; set; }

    public List<ShoppingCartItemsModel>? ShoppingCartItems { get; set; }
}

public class ShoppingCartItemsModel
{
    public int Id { get; set; }
    public int ShoppingCartId { get; set; }
    public int ProductId { get; set; }
}