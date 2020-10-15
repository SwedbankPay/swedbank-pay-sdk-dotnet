using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Net.Http;

namespace SwedbankPay.Sdk.Payments
{
    public class PaymentsResource: ResourceBase, IPaymentsResource
    {
        public ICardResource CardPayments { get; }
        public ISwishResource SwishPayments { get; }
        public IInvoiceResource InvoicePayments { get; }
        public IVippsResource VippsPayments { get; }
        public IMobilePayResource MobilePayPayments { get; }
        public ITrustlyResource TrustlyPayments { get; }

        
        public PaymentsResource(HttpClient httpClient)
            : this(httpClient,
                   new CardPaymentsResource(httpClient),
                   new SwishPaymentsResource(httpClient),
                   new InvoicePaymentsResource(httpClient),
                   new VippsPaymentsResource(httpClient),
                   new MobilePayPaymentsResource(httpClient),
                   new TrustlyPaymentsResource(httpClient))
        {
        }

        public PaymentsResource(HttpClient httpClient,
                                ICardResource cardPaymentsResource,
                                ISwishResource swishPaymentsResource,
                                IInvoiceResource invoicePaymentsResource,
                                IVippsResource vippsPaymentsResource,
                                IMobilePayResource mobilePayPaymentsResource,
                                ITrustlyResource trustlyPaymentsResource) 
                                : base(httpClient)
        {
            this.CardPayments = cardPaymentsResource ?? throw new ArgumentNullException(nameof(cardPaymentsResource));
            this.SwishPayments = swishPaymentsResource ?? throw new ArgumentNullException(nameof(swishPaymentsResource));
            this.InvoicePayments = invoicePaymentsResource ?? throw new ArgumentNullException(nameof(invoicePaymentsResource));
            this.VippsPayments = vippsPaymentsResource ?? throw new ArgumentNullException(nameof(vippsPaymentsResource));
            this.MobilePayPayments = mobilePayPaymentsResource ?? throw new ArgumentNullException(nameof(mobilePayPaymentsResource));
            this.TrustlyPayments = trustlyPaymentsResource ?? throw new ArgumentNullException(nameof(trustlyPaymentsResource));

        }
    }
}
