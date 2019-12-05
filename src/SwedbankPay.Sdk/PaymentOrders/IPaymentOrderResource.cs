namespace SwedbankPay.Sdk.PaymentOrders
{
    using SwedbankPay.Sdk.Exceptions;
    using SwedbankPay.Sdk.Transactions;

    using System.Threading.Tasks;

    public interface IPaymentOrderResource
    {
        /// <summary>
        /// Creates a payment order
        /// </summary>
        /// <param name="paymentOrderRequest"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <returns></returns>
        Task<PaymentOrder> Create(PaymentOrderRequest paymentOrderRequest, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);
        
        /// <summary>
        /// Get payment order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <returns></returns>
        Task<PaymentOrder> Get(string id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);

    }
}
