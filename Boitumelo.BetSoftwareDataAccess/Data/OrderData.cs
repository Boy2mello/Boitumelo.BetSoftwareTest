using Boitumelo.BetSoftwareDataAccess.DataAccess;
using Boitumelo.BetSoftwareDataAccess.Interface;
using Boitumelo.BetSoftwareDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareDataAccess.Data;
public class OrderData : IOrderData
{
    private readonly ISqlDataAccess _db;
    public OrderData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<OrderModel>> GetOrders() =>
        _db.LoadData<OrderModel, dynamic>("[dbo].[sp_GetOrders]", new { });

    public async Task<OrderModel?> GetOrder(int id) =>
     (await _db.LoadData<OrderModel, dynamic>
                    ("[dbo].[sp_GetOrdersById]", new { id })).FirstOrDefault();

    public async Task<OrderModel?> GetOrdersByShippingMethod(int id) =>
     (await _db.LoadData<OrderModel, dynamic>
                    ("[dbo].[sp_GetOrdersByShippingMethodId]", new { id })).FirstOrDefault();

    public async Task<OrderModel?> GetOrdersBySalesPerson(int id) =>
     (await _db.LoadData<OrderModel, dynamic>
                    ("[dbo].[sp_GetOrdersBySalesPersonId]", new { id })).FirstOrDefault();

    public async Task<OrderModel?> GetOrdersByCustomer(int id) =>
    (await _db.LoadData<OrderModel, dynamic>
                   ("[dbo].[sp_GetOrdersByCustomerId]", new { id })).FirstOrDefault();
    public Task InsertOrder(OrderModel model) =>
        _db.SaveData("[dbo].[sp_InsertOrders]", new
        {
            model.ShippingMethodId,
            model.SalesPersonId,
            model.CustomerId,
            model.OrderDate
        });

    public Task UpdateOrder(OrderModel model) =>
    _db.SaveData("[dbo].[sp_UpdateOrders]", new { model });

    public Task DeleteOrder(int id) =>
        _db.SaveData("[dbo].[sp_DeleteOrders]", new { id });
}
