using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentInstruments.Invoice;
using SwedbankPay.Sdk.PaymentInstruments.MobilePay;
using SwedbankPay.Sdk.PaymentInstruments.Swish;
using SwedbankPay.Sdk.PaymentInstruments.Trustly;
using SwedbankPay.Sdk.PaymentInstruments.Vipps;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    public class PaymentRequestBuilder
    {
        private Operation operation;
        private PaymentIntent intent;
        private CurrencyCode currency;
        private string description;
        private string userAgent;
        private CultureInfo language;
        private Urls urls;
        private PayeeInfo payeeInfo;
        private PrefillInfo prefillInfo;
        private TrustlyPrefillInfo trustlyPrefillInfo;
        private bool generatePaymentToken;
        private bool generateReccurrenceToken;
        private Amount amount;
        private Amount vatAmount;
        private string payerReference;
        private SwishPaymentOptionsObject swish;
        private List<IPrice> price;
        private MetadataResponse metadata;
        private InvoiceType invoiceType;
        private Uri shopslogoUrl;


        public CardPaymentRequest BuildCreditardPaymentRequest()
        {
            return new CardPaymentRequest(
                this.operation,
                this.intent,
                this.currency,
                this.price,
                this.description,
                this.userAgent,
                this.language,
                this.urls,
                this.payeeInfo,
                generatePaymentToken: this.generatePaymentToken, generateReccurenceToken: false, payerReference: this.payerReference, riskIndicator: null, metadata: this.metadata);
        }

        public SwishPaymentRequest BuildSwishPaymentRequest() => new SwishPaymentRequest(this.currency,
                                      this.price,
                                      this.description,
                                      this.payerReference,
                                      this.userAgent,
                                      this.language,
                                      this.urls,
                                      this.payeeInfo,
                                      this.prefillInfo,
                                      metadata: this.metadata
            );

        public InvoicePaymentRequest BuildInvoiceRequest() => new InvoicePaymentRequest(
                this.operation,
                this.intent,
                this.currency,
                this.price,
                this.description,
                this.userAgent,
                this.language,
                this.urls,
                this.payeeInfo,
                this.invoiceType);

        public VippsPaymentRequest BuildVippsRequest() => new VippsPaymentRequest(
                this.operation,
                this.intent,
                this.currency,
                this.price,
                this.description,
                this.userAgent,
                this.language,
                this.urls,
                this.payeeInfo,
                this.payerReference,
                this.generatePaymentToken,
                this.generateReccurrenceToken,
                this.metadata);

        public MobilePayPaymentRequest BuildMobilePayRequest() => new MobilePayPaymentRequest(
                this.operation,
                this.intent,
                this.currency,
                this.price,
                this.description,
                this.userAgent,
                this.language,
                this.urls,
                this.payeeInfo,
                this.shopslogoUrl);

        public TrustlyPaymentRequest BuildTrustlyRequest()
        {
            return new TrustlyPaymentRequest(
                this.currency,
                this.price,
                this.description,
                this.payerReference,
                this.userAgent,
                this.language,
                this.urls,
                this.payeeInfo,
                this.trustlyPrefillInfo);
        }

        public PaymentRequestBuilder WithCreditcardTestValues(Guid payeeId, Operation operation = null, PaymentIntent intent = PaymentIntent.Authorization)
        {
            this.operation = operation ?? Operation.Purchase;
            this.intent = intent;
            this.currency = new CurrencyCode("SEK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new CultureInfo("sv-SE");
            this.urls = new Urls(new UrlsDto
            {
                HostUrls = new List<Uri> { new Uri("https://example.com") },
                CompleteUrl = "https://example.com/payment-completed",
                CallbackUrl = "https://example.com/payment-callback",
                TermsOfServiceUrl = "https://example.com/termsandconditoons.pdf",
                CancelUrl = "https://example.com/payment-canceled"
            });
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            this.generatePaymentToken = false;
            this.amount = new Amount(1600);
            this.vatAmount = new Amount(0);
            this.metadata = new MetadataResponse { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            this.price = new List<IPrice>
            {
                new Price(this.amount, PriceType.CreditCard, this.vatAmount)
            };

            return this;
        }


        public PaymentRequestBuilder WithSwishTestValues(Guid payeeId)
        {
            this.operation = Operation.Purchase;
            this.intent = PaymentIntent.Sale;
            this.currency = new CurrencyCode("SEK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new CultureInfo("sv-SE");
            this.urls = new Urls(new UrlsDto
            {
                HostUrls = new List<Uri> { new Uri("https://example.com") },
                CallbackUrl = "https://example.com/payment-completed",
                TermsOfServiceUrl = "https://example.com/termsandconditoons.pdf",
                CancelUrl = "https://example.com/payment-canceled"
            });
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            this.prefillInfo = new PrefillInfo(new Msisdn("+46701234567"));
            this.generatePaymentToken = false;
            this.amount = new Amount(1600);
            this.vatAmount = new Amount(0);
            this.swish = new SwishPaymentOptionsObject();
            this.metadata = new MetadataResponse { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            this.price = new List<IPrice>
            {
                new Price(this.amount, PriceType.Swish, this.vatAmount)
            };
            return this;
        }

        public PaymentRequestBuilder WithInvoiceTestValues(Guid payeeId, Operation operation = null)
        {
            this.operation = operation ?? Operation.FinancingConsumer;
            this.intent = PaymentIntent.Authorization;
            this.currency = new CurrencyCode("NOK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new CultureInfo("nb-NO");
            this.urls = new Urls(new UrlsDto
            {
                HostUrls = new List<Uri> { new Uri("https://example.com") },
                CallbackUrl = "https://example.com/payment-completed",
                TermsOfServiceUrl = "https://example.com/termsandconditoons.pdf",
                CancelUrl = "https://example.com/payment-canceled"
            });
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            this.generatePaymentToken = false;
            this.amount = new Amount(1600);
            this.vatAmount = new Amount(0);
            this.metadata = new MetadataResponse { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            this.invoiceType = InvoiceType.PayExFinancingNO;
            this.price = new List<IPrice>
            {
                new Price(this.amount, PriceType.Invoice, this.vatAmount)
            };
            return this;
        }

        public PaymentRequestBuilder WithVippsTestValues(Guid payeeId, Operation operation = null, PaymentIntent PaymentIntent = PaymentIntent.Authorization)
        {
            this.operation = operation ?? Operation.Purchase;
            this.currency = new CurrencyCode("NOK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new CultureInfo("nb-NO");
            this.urls = new Urls(new UrlsDto
            {
                HostUrls = new List<Uri> { new Uri("https://example.com") },
                CallbackUrl = "https://example.com/payment-completed",
                TermsOfServiceUrl = "https://example.com/termsandconditoons.pdf",
                CancelUrl = "https://example.com/payment-canceled"
            });
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            this.generatePaymentToken = false;
            this.amount = new Amount(1600);
            this.vatAmount = new Amount(0);
            this.metadata = new MetadataResponse { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };

            this.price = new List<IPrice>
            {
                new Price(this.amount, PriceType.Vipps, this.vatAmount)
            };
            return this;
        }

        public PaymentRequestBuilder WithMobilePayTestValues(Guid payeeId)
        {
            this.operation = Operation.Purchase;
            this.intent = PaymentIntent.Authorization;
            this.currency = new CurrencyCode("SEK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new CultureInfo("sv-SE");
            this.urls = new Urls(new UrlsDto
            {
                HostUrls = new List<Uri> { new Uri("https://example.com") },
                CallbackUrl = "https://example.com/payment-completed",
                TermsOfServiceUrl = "https://example.com/termsandconditoons.pdf",
                CancelUrl = "https://example.com/payment-canceled"
            });
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString(), "payeeName", "productCategory");
            this.prefillInfo = new PrefillInfo(new Msisdn("+46701234567"));
            this.amount = new Amount(1600);
            this.vatAmount = new Amount(0);
            this.metadata = new MetadataResponse { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            this.shopslogoUrl = new Uri("https://example.com");
            this.price = new List<IPrice>
            {
                new Price(this.amount, PriceType.Visa, this.vatAmount)
            };
            return this;
        }


        public PaymentRequestBuilder WithTruslyTestValues(Guid payeeId)
        {
            return WithTruslyTestValues(payeeId, Operation.Purchase);
        }


        public PaymentRequestBuilder WithTruslyTestValues(Guid payeeId, Operation operation)
        {
            this.operation = operation ?? Operation.Purchase;
            this.intent = PaymentIntent.Sale;
            this.currency = new CurrencyCode("SEK");
            this.description = "Test Purchase";
            this.payerReference = "SomeReference";
            this.userAgent = "Mozilla/5.0...";
            this.language = new CultureInfo("sv-SE");
            this.urls = new Urls(new UrlsDto
            {
                HostUrls = new List<Uri> { new Uri("https://example.com") },
                CallbackUrl = "https://example.com/payment-completed",
                TermsOfServiceUrl = "https://example.com/termsandconditoons.pdf",
                CancelUrl = "https://example.com/payment-canceled"
            });
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            this.amount = new Amount(1600);
            this.vatAmount = new Amount(0);
            this.metadata = new MetadataResponse { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            this.price = new List<IPrice>
            {
                new Price(this.amount, PriceType.Trustly, this.vatAmount)
            };
            this.trustlyPrefillInfo = new TrustlyPrefillInfo("Ola", "Nordmann");
            return this;
        }
    }
}