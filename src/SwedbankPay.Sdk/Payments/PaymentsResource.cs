using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    internal class PaymentsResource : ResourceBase, IPaymentsResource
    {
        public PaymentsResource(SwedbankPayHttpClient swedbankPayHttpClient)
            : base(swedbankPayHttpClient)
        {
        }


        public async Task<Payment> Create(PaymentType paymentType,
                                          PaymentRequest paymentRequest,
                                          PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return await Payment.Create(paymentType, paymentRequest, this.swedbankPayHttpClient, GetExpandQueryString(paymentExpand));
        }


        public async Task<Payment> CreateCreditCardPayment(PaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return await Payment.Create(PaymentType.CreditCard, paymentRequest, this.swedbankPayHttpClient,
                                        GetExpandQueryString(paymentExpand));
        }


        public Task<Payment> Get(Uri id, PaymentExpand paymentExpand)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return GetInternalAsync(id, paymentExpand);
        }


        private async Task<Payment> GetInternalAsync(Uri id, PaymentExpand paymentExpand)
        {
            return await Payment.Get(id, this.swedbankPayHttpClient, GetExpandQueryString(paymentExpand));
        }
    }
}