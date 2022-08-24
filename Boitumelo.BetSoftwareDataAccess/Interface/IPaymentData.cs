using Boitumelo.BetSoftwareDataAccess.Models;

namespace Boitumelo.BetSoftwareDataAccess.Interface;
public interface IPaymentData
{
    Task DeletePayment(int id);
    Task<PaymentModel?> GetPayment(int id);
    Task<IEnumerable<PaymentModel>> GetPayments();
    Task<PaymentModel?> GetPaymentsByOrder(int id);
    Task<PaymentModel?> GetPaymentsByPayment(int id);
    Task InsertPayment(PaymentModel model);
    Task UpdatePayment(PaymentModel model);
}