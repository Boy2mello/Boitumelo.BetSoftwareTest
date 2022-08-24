using Boitumelo.BetSoftwareDataAccess.Models;

namespace Boitumelo.BetSoftwareDataAccess.Interface;
public interface IOrderData
{
    Task DeleteOrder(int id);
    Task<OrderModel?> GetOrder(int id);
    Task<IEnumerable<OrderModel>> GetOrders();
    Task<OrderModel?> GetOrdersByCustomer(int id);
    Task<OrderModel?> GetOrdersBySalesPerson(int id);
    Task<OrderModel?> GetOrdersByShippingMethod(int id);
    Task InsertOrder(OrderModel model);
    Task UpdateOrder(OrderModel model);
}