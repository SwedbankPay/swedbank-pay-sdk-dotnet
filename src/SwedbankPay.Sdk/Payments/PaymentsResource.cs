using SwedbankPay.Sdk.Payments.CardPayments;
using SwedbankPay.Sdk.Payments.SwishPayments;
using SwedbankPay.Sdk.Payments.MobilePayPayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class PaymentsResource: ResourceBase, IPaymentsResource
    {
        public ICardPaymentsResource CardPayments { get; }
        public ISwishPaymentsResource SwishPayments { get; }
        public IMobilePayPaymentsResource MobilePayPayments { get; }
        
        public PaymentsResource(HttpClient httpClient)
            : this(httpClient, new CardPaymentsResource(httpClient), new SwishPaymentsResource(httpClient), new MobilePayPaymentsResource(httpClient))
        {
        }

        public PaymentsResource(HttpClient httpClient, ICardPaymentsResource cardPaymentsResource, ISwishPaymentsResource swishPaymentsResource, IMobilePayPaymentsResource mobilePayPaymentsResource) : base(httpClient)
        {
            this.CardPayments = cardPaymentsResource ?? throw new ArgumentNullException(nameof(cardPaymentsResource));
            this.SwishPayments = swishPaymentsResource ?? throw new ArgumentNullException(nameof(swishPaymentsResource));
            this.MobilePayPayments = mobilePayPaymentsResource ?? throw new ArgumentNullException(nameof(mobilePayPaymentsResource));

        }
    }
}
