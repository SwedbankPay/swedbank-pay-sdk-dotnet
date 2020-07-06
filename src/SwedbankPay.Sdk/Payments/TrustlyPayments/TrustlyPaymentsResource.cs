using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.TrustlyPayments
{
    public class TrustlyPaymentsResource : ResourceBase, ITrustlyPaymentsResource
    {
        public TrustlyPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }


        public Task<TrustlyPayment> Create(TrustlyPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return TrustlyPayment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }


        public Task<TrustlyPayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return TrustlyPayment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
