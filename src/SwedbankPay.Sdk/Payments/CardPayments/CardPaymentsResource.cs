using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentsResource : ResourceBase, ICardPaymentsResource
    {
        public CardPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<Payment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return Payment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }


        public Task<Payment> Create(CardPayments.CardPaymentPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return Payment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
