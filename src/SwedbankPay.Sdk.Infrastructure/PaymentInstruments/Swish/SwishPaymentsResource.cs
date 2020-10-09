using SwedbankPay.Sdk.Payments.SwishPayments;
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

        public Task<ISwishPayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return SwishPayment.Get(id, this.HttpClient, GetExpandQueryString(paymentExpand));
        }

        public Task<ISwishPayment> Create(SwishPaymentRequest paymentRequest,
                                                            PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return SwishPayment.Create(paymentRequest, this.HttpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
