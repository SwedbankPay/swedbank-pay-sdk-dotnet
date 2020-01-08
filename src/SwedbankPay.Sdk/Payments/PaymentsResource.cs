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

        public async Task<Card.Payment> GetCreditCardPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await Card.Payment.Get(id, this.swedbankPayHttpClient, GetExpandQueryString(paymentExpand));
        }


        public async Task<Card.Payment> CreateCreditCardPayment(Card.PaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None)
        {
           throw new NotImplementedException();
        }


        public async Task<Swish.Payment> GetSwishPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await Swish.Payment.Get(id, this.swedbankPayHttpClient, GetExpandQueryString(paymentExpand));
        }



        public async Task<Swish.Payment> CreateSwishPayment(Swish.PaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return await Swish.Payment.Create(paymentRequest, this.swedbankPayHttpClient, GetExpandQueryString(paymentExpand));
        }
    }
}