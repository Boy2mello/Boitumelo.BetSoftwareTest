using Boitumelo.BetSoftwareDataAccess.Models;

namespace Boitumelo.BetSoftwareDataAccess.Interface;
public interface IOrderDetailData
{
    Task DeleteOrderDetail(int id);
    Task<OrderDetailModel?> GetOrderDetail(int id);
    Task<IEnumerable<OrderDetailModel>> GetOrderDetails();
    Task<ContactTypeModel?> GetOrderDetailsByOrder(int id);
    Task<ContactTypeModel?> GetOrderDetailsByProduct(int id);
    Task InsertOrderDetail(OrderDetailModel model);
    Task UpdateOrderDetail(OrderDetailModel model);
}