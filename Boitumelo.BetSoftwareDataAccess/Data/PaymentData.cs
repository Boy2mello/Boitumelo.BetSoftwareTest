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
public class PaymentData : IPaymentData
{
    private readonly ISqlDataAccess _db;
    public PaymentData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<PaymentModel>> GetPayments() =>
        _db.LoadData<PaymentModel, dynamic>("[dbo].[sp_GetPayments]", new { });

    public async Task<PaymentModel?> GetPayment(int id) =>
     (await _db.LoadData<PaymentModel, dynamic>
                    ("[dbo].[sp_GetPaymentsById]", new { id })).FirstOrDefault();

    public async Task<PaymentModel?> GetPaymentsByOrder(int id) =>
     (await _db.LoadData<PaymentModel, dynamic>
                    ("[dbo].[sp_GetPaymentsByOrderId]", new { id })).FirstOrDefault();

    public async Task<PaymentModel?> GetPaymentsByPayment(int id) =>
     (await _db.LoadData<PaymentModel, dynamic>
                    ("[dbo].[sp_GetPaymentsByPaymentId]", new { id })).FirstOrDefault();

    public Task InsertPayment(PaymentModel model) =>
        _db.SaveData("[dbo].[sp_InsertPayments]", new
        {

            model.OrderId,
            model.PaymentId,
            model.PaymentAmount,
            model.PaymentDate,
            model.CardNumber,
            model.CardExpiryDate,
            model.CardHolderName
        });

    public Task UpdatePayment(PaymentModel model) =>
    _db.SaveData("[dbo].[sp_UpdatePayments]", new { model });

    public Task DeletePayment(int id) =>
        _db.SaveData("[dbo].[sp_DeletePayments]", new { id });
}
