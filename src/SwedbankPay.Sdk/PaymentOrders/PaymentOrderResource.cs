using System;
using System.Net.Http;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Exceptions;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderResource : ResourceBase, IPaymentOrderResource
    {
        public PaymentOrderResource(HttpClient httpClient)
            : base(httpClient)
        {
        }


        /// <summary>
        ///     Create a payment order
        /// </summary>
        /// <param name="paymentOrderRequest"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <returns></returns>
        public async Task<PaymentOrder> Create(PaymentOrderRequest paymentOrderRequest,
                                               PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            return await PaymentOrder.Create(paymentOrderRequest, httpClient, GetExpandQueryString(paymentOrderExpand));
        }

        /// <summary>
        ///     Get payment order by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="HttpResponseException"></exception>
        public Task<PaymentOrder> Get(Uri id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), $"{id} cannot be null");

            return GetInternalAsync(id, paymentOrderExpand);
        }

        /// <summary>
        ///     Get payment order by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <returns></returns>
        private async Task<PaymentOrder> GetInternalAsync(Uri id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            return await PaymentOrder.Get(id, httpClient, GetExpandQueryString(paymentOrderExpand));
        }
    }
}