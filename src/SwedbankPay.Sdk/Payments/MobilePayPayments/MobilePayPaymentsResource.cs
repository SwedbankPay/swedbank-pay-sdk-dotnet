using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayPaymentsResource : ResourceBase, IMobilePayPaymentsResource
    {
        public MobilePayPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<MobilePayPayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return MobilePayPayment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }

        public Task<MobilePayPayment> Create(MobilePayPaymentRequest paymentRequest,
                                                            PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return MobilePayPayment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
