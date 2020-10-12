using SwedbankPay.Sdk.Payments.CardPayments;
using SwedbankPay.Sdk.Payments.SwishPayments;
using SwedbankPay.Sdk.Payments.InvoicePayments;
using SwedbankPay.Sdk.Payments.VippsPayments;
using SwedbankPay.Sdk.Payments.MobilePayPayments;
using System;
using System.Net.Http;

using SwedbankPay.Sdk.Payments.TrustlyPayments;

namespace SwedbankPay.Sdk.Payments
{
    public class PaymentsResource: ResourceBase, IPaymentsResource
    {
        public ICardResource CardPayments { get; }
        public ISwishResource SwishPayments { get; }
        public IInvoiceResource InvoicePayments { get; }
        public IVippsResource VippsPayments { get; }
        public IMobileResource MobilePayPayments { get; }
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
                                IMobileResource mobilePayPaymentsResource,
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
