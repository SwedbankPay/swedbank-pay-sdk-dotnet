using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentInstruments.Invoice;
using SwedbankPay.Sdk.PaymentInstruments.MobilePay;
using SwedbankPay.Sdk.PaymentInstruments.Swish;
using SwedbankPay.Sdk.PaymentInstruments.Trustly;
using SwedbankPay.Sdk.PaymentInstruments.Vipps;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    public class PaymentRequestBuilder
    {
        private Operation operation;
        private PaymentIntent intent;
        private Currency currency;
        private string description;
        private string userAgent;
        private Language language;
        private IUrls urls;
        private PayeeInfo payeeInfo;
        private PrefillInfo prefillInfo;
        private TrustlyPrefillInfo trustlyPrefillInfo;
        private bool generatePaymentToken;
        private Amount amount;
        private Amount vatAmount;
        private string payerReference;
        private List<IPrice> price;
        private Metadata metadata;
        private InvoiceType invoiceType;
        private Uri shopslogoUrl;


        public CardPaymentRequest BuildCreditardPaymentRequest()
        {
            var req = new CardPaymentRequest(this.operation, this.intent, this.currency, this.description, this.userAgent, this.language, this.urls, this.payeeInfo);
            req.Payment.Prices.AddRange(this.price);
            req.Payment.GeneratePaymentToken = this.generatePaymentToken;
            req.Payment.PayerReference = this.payerReference;
            req.Payment.Metadata = metadata;

            return req;
        }

        public SwishPaymentRequest BuildSwishPaymentRequest()
        {
            var req = new SwishPaymentRequest(this.price, this.description, this.payerReference, this.userAgent, this.language, this.urls, this.payeeInfo, this.prefillInfo);
            req.Payment.Metadata = this.metadata;

            return req;
        }

        public InvoicePaymentRequest BuildInvoiceRequest()
        {
            var req = new InvoicePaymentRequest(this.operation, this.intent, this.currency, this.price, this.description, this.userAgent, this.language, this.urls, this.payeeInfo, this.invoiceType);
            req.Payment.Metadata = this.metadata;

            return req;
        }

        public VippsPaymentRequest BuildVippsRequest()
        {
            var req = new VippsPaymentRequest(this.operation, this.intent, this.currency, this.price, this.description, this.userAgent, this.language, this.urls, this.payeeInfo, this.payerReference);
            req.Payment.GeneratePaymentToken = this.generatePaymentToken;
            req.Payment.Metadata = this.metadata;
            return req;
        }

        public MobilePayPaymentRequest BuildMobilePayRequest()
        {
            var req = new MobilePayPaymentRequest(this.operation, this.intent, this.currency, this.price, this.description, this.userAgent, this.language, this.urls, this.payeeInfo, this.shopslogoUrl);

            return req;
        }

        public TrustlyPaymentRequest BuildTrustlyRequest()
        {
            var req = new TrustlyPaymentRequest(this.currency, this.price,this.description, this.payerReference, this.userAgent, this.language, this.urls, this.payeeInfo);
            req.Payment.PrefillInfo = trustlyPrefillInfo;
            return req;
        }

        public PaymentRequestBuilder WithCreditcardTestValues(Guid payeeId, Operation testOperation = null, PaymentIntent paymentIntent = PaymentIntent.Authorization)
        {
            this.operation = testOperation ?? Operation.Purchase;
            this.intent = paymentIntent;
            this.currency = new Currency("SEK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new Language("sv-SE");
            SetUrls();
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            this.generatePaymentToken = false;
            this.amount = new Amount(1600);
            this.vatAmount = new Amount(0);
            this.metadata = new Metadata { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
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
            this.currency = new Currency("SEK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new Language("sv-SE");
            SetUrls();
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            this.prefillInfo = new PrefillInfo(new Msisdn("+46701234567"));
            this.generatePaymentToken = false;
            this.amount = new Amount(1600);
            this.vatAmount = new Amount(0);
            this.metadata = new Metadata { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            this.price = new List<IPrice>
            {
                new Price(this.amount, PriceType.Swish, this.vatAmount)
            };
            return this;
        }

        public PaymentRequestBuilder WithInvoiceTestValues(Guid payeeId, Operation testOperation = null)
        {
            this.operation = testOperation ?? Operation.FinancingConsumer;
            this.intent = PaymentIntent.Authorization;
            this.currency = new Currency("NOK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new Language("nb-NO");
            SetUrls();
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            this.generatePaymentToken = false;
            this.amount = new Amount(1600);
            this.vatAmount = new Amount(0);
            this.metadata = new Metadata { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            this.invoiceType = InvoiceType.PayExFinancingNO;
            this.price = new List<IPrice>
            {
                new Price(this.amount, PriceType.Invoice, this.vatAmount)
            };
            return this;
        }

        public PaymentRequestBuilder WithVippsTestValues(Guid payeeId, Operation testOperation = null)
        {
            this.operation = testOperation ?? Operation.Purchase;
            this.intent = PaymentIntent.Authorization;
            this.currency = new Currency("NOK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new Language("nb-NO");
            SetUrls();
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            this.generatePaymentToken = false;
            this.amount = new Amount(123.45M);
            this.vatAmount = new Amount(0);
            this.metadata = new Metadata { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };

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
            this.currency = new Currency("SEK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new Language("sv-SE");
            SetUrls();
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString())
            {
                PayeeName = "payeeName",
                ProductCategory = "productCategory"
            };
            this.prefillInfo = new PrefillInfo(new Msisdn("+46701234567"));
            this.amount = new Amount(1600);
            this.vatAmount = new Amount(0);
            this.metadata = new Metadata { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
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


        public PaymentRequestBuilder WithTruslyTestValues(Guid payeeId, Operation testOperation)
        {
            this.operation = testOperation ?? Operation.Purchase;
            this.intent = PaymentIntent.Sale;
            this.currency = new Currency("SEK");
            this.description = "Test Purchase";
            this.payerReference = "SomeReference";
            this.userAgent = "Mozilla/5.0...";
            this.language = new Language("sv-SE");
            SetUrls();
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            this.amount = new Amount(1600);
            this.vatAmount = new Amount(0);
            this.metadata = new Metadata { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            this.price = new List<IPrice>
            {
                new Price(this.amount, PriceType.Trustly, this.vatAmount)
            };
            this.trustlyPrefillInfo = new TrustlyPrefillInfo("Ola", "Nordmann");
            return this;
        }

        private void SetUrls()
        {
            this.urls = new UrlsResponse(new UrlsDto
            {
                HostUrls = new List<Uri> { new Uri("https://example.com") },
                CompleteUrl = new Uri("https://example.com/payment-completed"),
                CallbackUrl = new Uri("https://example.com/payment-callback"),
                TermsOfServiceUrl = new Uri("https://example.com/termsandconditoons.pdf"),
                CancelUrl = new Uri("https://example.com/payment-canceled")
            });
        }
    }
}