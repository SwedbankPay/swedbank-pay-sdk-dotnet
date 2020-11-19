using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentsResource : ResourceBase, ICardPaymentsResource
    {
        public CardPaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<CardPayment> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return CardPayment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }


        public Task<CardPayment> Create(CardPayments.CardPaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return CardPayment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }


        public Task<CardPayment> Create(CardPayments.CardPaymentRecurRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return CardPayment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
