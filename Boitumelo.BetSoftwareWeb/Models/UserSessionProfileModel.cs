using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Boitumelo.BetSoftwareWeb.Models
{
    public class UserSessionProfileModel
    {
        public int ProfileId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public int ContactId { get; set; }
        [Required]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string TenantId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ShoppingCartModel ShoppingCart { get; set; }
    }

    public class ShoppingCartModel
    {
        public int ShoppingCartId { get; set; }
        public int UserId { get; set; }
        public int Id { get; set; }
        public bool IsOrdered { get; set; }
        public string OrderId { get; set; }
        public List<ShoppingCartItemsModel> ShoppingCartItems { get; set; }
    }

    public class ShoppingCartItemsModel
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
    }
}