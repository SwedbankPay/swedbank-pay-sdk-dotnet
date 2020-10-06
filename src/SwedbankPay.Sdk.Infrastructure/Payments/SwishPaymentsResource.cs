using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class SwishPaymentsResource : ResourceBase, ISwishPaymentsResource
    {
        public SwishPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<SwishPayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return SwishPayment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }

        public Task<SwishPayment> Create(SwishPaymentRequest paymentRequest,
                                                            PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return SwishPayment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
