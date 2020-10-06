using SwedbankPay.Sdk.Payments.TrustlyPayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class TrustlyPaymentsResource : ResourceBase, ITrustlyPaymentsResource
    {
        public TrustlyPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<ITrustlyPayment> Create(TrustlyPaymentRequest paymentRequest)
        {
            return Create(paymentRequest, PaymentExpand.None);
        }

        public Task<ITrustlyPayment> Create(TrustlyPaymentRequest paymentRequest, PaymentExpand paymentExpand)
        {
            return TrustlyPayment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }

        public Task<ITrustlyPayment> Get(Uri id)
        {
            return Get(id, PaymentExpand.None);
        }

        public Task<ITrustlyPayment> Get(Uri id, PaymentExpand paymentExpand)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return TrustlyPayment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
