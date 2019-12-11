using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface IPaymentOrderResource
    {
        /// <summary>
        ///     Creates a payment order
        /// </summary>
        /// <param name="paymentOrderRequest"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <returns></returns>
        Task<PaymentOrder> Create(PaymentOrderRequest paymentOrderRequest, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);


        /// <summary>
        ///     Get payment order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <returns></returns>
        Task<PaymentOrder> Get(string id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);
    }
}