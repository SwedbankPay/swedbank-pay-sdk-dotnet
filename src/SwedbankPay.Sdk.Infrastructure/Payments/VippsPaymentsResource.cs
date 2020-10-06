using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class VippsPaymentsResource : ResourceBase, IVippsPaymentsResource
    {
        public VippsPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<VippsPayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return VippsPayment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }

        public Task<VippsPayment> Create(VippsPaymentRequest paymentRequest,
                                                            PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return VippsPayment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
