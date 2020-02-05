using SwedbankPay.Sdk.Payments.CardPayments;
using SwedbankPay.Sdk.Payments.SwishPayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class PaymentsResource: ResourceBase, IPaymentsResource
    {
        public ICardPaymentsResource CardPayments { get; }
        public ISwishPaymentsResource SwishPayments { get; }
        
        public PaymentsResource(HttpClient httpClient)
            : this(httpClient, new CardPaymentsResource(httpClient), new SwishPaymentsResource(httpClient))
        {
        }

        public PaymentsResource(HttpClient httpClient, ICardPaymentsResource cardPaymentsResource, ISwishPaymentsResource swishPaymentsResource) : base(httpClient)
        {
            this.CardPayments = cardPaymentsResource ?? throw new ArgumentNullException(nameof(cardPaymentsResource));
            this.SwishPayments = swishPaymentsResource ?? throw new ArgumentNullException(nameof(swishPaymentsResource));
        }


        public async Task<Vipps.Payment> GetVippsPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await Vipps.Payment.Get(id, this.swedbankPayHttpClient, GetExpandQueryString(paymentExpand));
        }


        public async Task<Vipps.Payment> CreateVippsPayment(Vipps.PaymentRequest paymentRequest,
                                                            PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return await Vipps.Payment.Create(paymentRequest, this.swedbankPayHttpClient, GetExpandQueryString(paymentExpand));
        }
    }
}
