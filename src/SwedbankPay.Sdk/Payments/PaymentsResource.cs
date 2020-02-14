using SwedbankPay.Sdk.Payments.CardPayments;
using SwedbankPay.Sdk.Payments.SwishPayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class PaymentsResource: ResourceBase, IPaymentsResource
    {
        public ICardPaymentsResource CardPayments { get; private set ; }
        public ISwishPaymentsResource SwishPayments { get; private set; }
        
        public PaymentsResource(HttpClient httpClient) : base(httpClient)
        {
            this.CardPayments = new CardPaymentsResource(httpClient);
            this.SwishPayments = new SwishPaymentsResource(httpClient);
        }

        public PaymentsResource(HttpClient httpClient, ICardPaymentsResource cardPaymentsResource, ISwishPaymentsResource swishPaymentsResource) : base(httpClient)
        {
            this.CardPayments = cardPaymentsResource;
            this.SwishPayments = swishPaymentsResource;
        }
    }
}
