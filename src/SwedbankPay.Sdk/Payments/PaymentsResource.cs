using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class PaymentsResource: ResourceBase, IPaymentsResource
    {
        public PaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<CardPayments.Payment> GetCreditCardPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return CardPayments.Payment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }


        public Task<CardPayments.Payment> CreateCreditCardPayment(CardPayments.PaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return CardPayments.Payment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }


        public Task<Payments.Swish.Payment> GetSwishPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return Payments.Swish.Payment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }


        public Task<Payments.Swish.Payment> CreateSwishPayment(Payments.Swish.PaymentRequest paymentRequest,
                                                            PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return Payments.Swish.Payment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
