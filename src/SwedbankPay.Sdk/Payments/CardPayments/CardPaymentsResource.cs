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

        public Task<Payment> GetCreditCardPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return Payment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }


        public Task<Payment> CreateCreditCardPayment(CardPayments.PaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return Payment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
