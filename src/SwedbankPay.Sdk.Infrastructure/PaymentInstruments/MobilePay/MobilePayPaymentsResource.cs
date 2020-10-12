using SwedbankPay.Sdk.Payments.MobilePayPayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class MobilePayPaymentsResource : ResourceBase, IMobileResource
    {
        public MobilePayPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<IMobilePayPayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return MobilePayPayment.Get(id, this.HttpClient, GetExpandQueryString(paymentExpand));
        }

        public Task<IMobilePayPayment> Create(MobilePayPaymentRequest paymentRequest,
                                                            PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return MobilePayPayment.Create(paymentRequest, this.HttpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
