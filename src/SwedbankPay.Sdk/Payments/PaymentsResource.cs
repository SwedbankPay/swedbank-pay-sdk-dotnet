using SwedbankPay.Sdk.Payments.Card;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    internal class PaymentsResource: ResourceBase, IPaymentsResource
    {
        public PaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<Payment> GetCreditCardPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await Payment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }


        public async Task<Payment> CreateCreditCardPayment(PaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return await Payment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }


        public async Task<Payments.Swish.Payment> GetSwishPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await Payments.Swish.Payment.Get(id, this.httpClient, GetExpandQueryString(paymentExpand));
        }


        public async Task<Payments.Swish.Payment> CreateSwishPayment(Payments.Swish.PaymentRequest paymentRequest,
                                                            PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return await Payments.Swish.Payment.Create(paymentRequest, this.httpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
