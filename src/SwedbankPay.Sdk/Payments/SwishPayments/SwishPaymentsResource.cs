using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SwishPaymentsResource : ResourceBase, ISwishPaymentsResource
    {
        public SwishPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<Payment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return Payment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }

        public Task<Payment> Create(PaymentRequest paymentRequest,
                                                            PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return Payment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
