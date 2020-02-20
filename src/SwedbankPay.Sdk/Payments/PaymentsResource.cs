using SwedbankPay.Sdk.Payments.CardPayments;
using SwedbankPay.Sdk.Payments.SwishPayments;
using SwedbankPay.Sdk.Payments.InvoicePayments;
using SwedbankPay.Sdk.Payments.VippsPayments;
using SwedbankPay.Sdk.Payments.MobilePayPayments;
using System;
using System.Net.Http;

namespace SwedbankPay.Sdk.Payments
{
    public class PaymentsResource: ResourceBase, IPaymentsResource
    {
        public ICardPaymentsResource CardPayments { get; }
        public ISwishPaymentsResource SwishPayments { get; }
        public IInvoicePaymentsResource InvoicePayments { get; }
        public IVippsPaymentsResource VippsPayments { get; }
        public IMobilePayPaymentsResource MobilePayPayments { get; }

        
        public PaymentsResource(HttpClient httpClient)
            : this(httpClient, new CardPaymentsResource(httpClient), new SwishPaymentsResource(httpClient), new InvoicePaymentsResource(httpClient), new VippsPaymentsResource(httpClient), new MobilePayPaymentsResource(httpClient))
        {
        }

        public PaymentsResource(HttpClient httpClient,
                                ICardPaymentsResource cardPaymentsResource,
                                ISwishPaymentsResource swishPaymentsResource,
                                IInvoicePaymentsResource invoicePaymentsResource,
                                IVippsPaymentsResource vippsPaymentsResource,
                                IMobilePayPaymentsResource mobilePayPaymentsResource) 
                                : base(httpClient)
        {
            this.CardPayments = cardPaymentsResource ?? throw new ArgumentNullException(nameof(cardPaymentsResource));
            this.SwishPayments = swishPaymentsResource ?? throw new ArgumentNullException(nameof(swishPaymentsResource));
            this.InvoicePayments = invoicePaymentsResource ?? throw new ArgumentNullException(nameof(invoicePaymentsResource));
            this.VippsPayments = vippsPaymentsResource ?? throw new ArgumentNullException(nameof(vippsPaymentsResource));
            this.MobilePayPayments = mobilePayPaymentsResource ?? throw new ArgumentNullException(nameof(mobilePayPaymentsResource));

        }
    }
}
