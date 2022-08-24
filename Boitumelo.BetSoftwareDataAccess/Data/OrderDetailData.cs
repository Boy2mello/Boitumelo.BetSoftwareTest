using Boitumelo.BetSoftwareDataAccess.DataAccess;
using Boitumelo.BetSoftwareDataAccess.Interface;
using Boitumelo.BetSoftwareDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Boitumelo.BetSoftwareDataAccess.Data;
public class OrderDetailData : IOrderDetailData
{
    private readonly ISqlDataAccess _db;
    public OrderDetailData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<OrderDetailModel>> GetOrderDetails() =>
        _db.LoadData<OrderDetailModel, dynamic>("[dbo].[sp_GetOrderDetails]", new { });

    public async Task<OrderDetailModel?> GetOrderDetail(int id) =>
     (await _db.LoadData<OrderDetailModel, dynamic>
                    ("[dbo].[sp_GetOrderDetailsById]", new { id })).FirstOrDefault();

    public async Task<ContactTypeModel?> GetOrderDetailsByProduct(int id) =>
     (await _db.LoadData<ContactTypeModel, dynamic>
                    ("[dbo].[sp_GetOrderDetailsByProductId]", new { id })).FirstOrDefault();

    public async Task<ContactTypeModel?> GetOrderDetailsByOrder(int id) =>
     (await _db.LoadData<ContactTypeModel, dynamic>
                    ("[dbo].[sp_GetOrderDetailsByOrderId]", new { id })).FirstOrDefault();

    public Task InsertOrderDetail(OrderDetailModel model) =>
        _db.SaveData("[dbo].[sp_InsertOrderDetails]", new
        {
            model.OrderId,
            model.ProductId,
            model.Quantity,
            model.UnitPrice,
            model.Discount
        });

    public Task UpdateOrderDetail(OrderDetailModel model) =>
    _db.SaveData("[dbo].[sp_UpdateOrderDetails]", new { model });

    public Task DeleteOrderDetail(int id) =>
        _db.SaveData("[dbo].[sp_DeleteOrderDetails]", new { id });
}
