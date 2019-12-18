using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderResource : ResourceBase, IPaymentOrderResource
    {
        public PaymentOrderResource(SwedbankPayHttpClient swedbankPayHttpClient)
            : base(swedbankPayHttpClient)
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
            return await PaymentOrder.Create(paymentOrderRequest, this.swedbankPayHttpClient, GetExpandQueryString(paymentOrderExpand));
        }


        /// <summary>
        ///     Get payment order by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <returns></returns>
        public async Task<PaymentOrder> Get(Uri id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), $"{id} cannot be null");

            return await PaymentOrder.Get(id, this.swedbankPayHttpClient, GetExpandQueryString(paymentOrderExpand));
        }
    }
}