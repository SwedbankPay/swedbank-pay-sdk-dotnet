using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderResource : ResourceBase, IPaymentOrderResource
    {
        public PaymentOrderResource(SwedbankPayOptions swedbankPayOptions,
                                    ILogger logger,
                                    HttpClient client)
            : base(swedbankPayOptions, logger, client)
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
            return await PaymentOrder.Create(paymentOrderRequest, this.swedbankPayClient, this.swedbankPayOptions, paymentOrderExpand);
        }


        /// <summary>
        ///     Get payment order by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <returns></returns>
        public async Task<PaymentOrder> Get(string id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            return await PaymentOrder.Get(id, this.swedbankPayClient, this.swedbankPayOptions, paymentOrderExpand);
        }
    }
}