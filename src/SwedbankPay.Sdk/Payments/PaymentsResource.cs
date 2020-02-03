using System;
using System.Net.Http;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Payments.Card;

namespace SwedbankPay.Sdk.Payments
{
    internal class PaymentsResource : ResourceBase, IPaymentsResource
    {
        public PaymentsResource(HttpClient httpClient)
            : base(httpClient)
        {
        }


        public async Task<Payment> GetCreditCardPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await Payment.Get(id, httpClient, GetExpandQueryString(paymentExpand));
        }


        public async Task<Payment> CreateCreditCardPayment(PaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return await Payment.Create(paymentRequest, httpClient, GetExpandQueryString(paymentExpand));
        }


        public async Task<Swish.Payment> GetSwishPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await Swish.Payment.Get(id, httpClient, GetExpandQueryString(paymentExpand));
        }


        public async Task<Swish.Payment> CreateSwishPayment(Swish.PaymentRequest paymentRequest,
                                                            PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return await Swish.Payment.Create(paymentRequest, httpClient, GetExpandQueryString(paymentExpand));
        }
    }
}