using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentInstruments.Invoice;
using SwedbankPay.Sdk.PaymentInstruments.MobilePay;
using SwedbankPay.Sdk.PaymentInstruments.Swish;
using SwedbankPay.Sdk.PaymentInstruments.Trustly;
using SwedbankPay.Sdk.PaymentInstruments.Vipps;
using System;
using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class PaymentsResource : ResourceBase, IPaymentInstrumentsResource
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
            CardPayments = cardPaymentsResource ?? throw new ArgumentNullException(nameof(cardPaymentsResource));
            SwishPayments = swishPaymentsResource ?? throw new ArgumentNullException(nameof(swishPaymentsResource));
            InvoicePayments = invoicePaymentsResource ?? throw new ArgumentNullException(nameof(invoicePaymentsResource));
            VippsPayments = vippsPaymentsResource ?? throw new ArgumentNullException(nameof(vippsPaymentsResource));
            MobilePayPayments = mobilePayPaymentsResource ?? throw new ArgumentNullException(nameof(mobilePayPaymentsResource));
            TrustlyPayments = trustlyPaymentsResource ?? throw new ArgumentNullException(nameof(trustlyPaymentsResource));

        }
    }
}
