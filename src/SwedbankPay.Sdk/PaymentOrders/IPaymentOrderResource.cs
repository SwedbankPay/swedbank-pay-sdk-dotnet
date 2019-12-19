using SwedbankPay.Sdk.Exceptions;

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
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Net.Http.HttpRequestException"></exception>
        /// <exception cref="HttpResponseException"></exception>
        /// <returns></returns>
        Task<PaymentOrder> Create(PaymentOrderRequest paymentOrderRequest, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);


        /// <summary>
        ///     Get payment order for the given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <exception cref="System.Net.Http.HttpRequestException"></exception>
        /// <exception cref="HttpResponseException"></exception>
        /// <returns></returns>
        Task<PaymentOrder> Get(Uri id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);
    }
}