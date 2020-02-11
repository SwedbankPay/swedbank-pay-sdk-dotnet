using SwedbankPay.Sdk.Payments.SwishPayments;
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


        public Task<SwishPayments.Payment> GetSwishPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return SwishPayments.Payment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }


        public Task<SwishPayments.Payment> CreateSwishPayment(PaymentRequest paymentRequest,
                                                            PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return SwishPayments.Payment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
