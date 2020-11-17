using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Payments.MobilePayPayments;
using SwedbankPay.Sdk.Payments.SwishPayments;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    public class PaymentRequestBuilder
    {
        private Operation operation;
        private Intent intent;
        private CurrencyCode currency;
        private string description;
        private string userAgent;
        private CultureInfo language;
        private Urls urls;
        private PayeeInfo payeeInfo;
        private PrefillInfo prefillInfo;
        private SwedbankPay.Sdk.Payments.TrustlyPayments.PrefillInfo trustlyPrefillInfo;
        private bool generatePaymentToken;
        private bool generateReccurrenceToken;
        private Amount amount;
        private Amount vatAmount;
        private string payerReference;
        private SwishPaymentOptionsObject swish;
        private List<Price> price;
        private Dictionary<string, object> metadata;
        private InvoiceType invoiceType;
        private Uri shopslogoUrl;


        public Payments.CardPayments.CardPaymentRequest BuildCreditardPaymentRequest()
        {
            return new Payments.CardPayments.CardPaymentRequest(
                this.operation,
                this.intent,
                this.currency,
                this.price,
                this.description,
                this.userAgent,
                this.language,
                this.urls,
                this.payeeInfo,
                generatePaymentToken: this.generatePaymentToken, generateRecurrenceToken: false, payerReference: this.payerReference, riskIndicator: null, metadata: this.metadata);
        }

        public SwishPaymentRequest BuildSwishPaymentRequest()
        {
            return new SwishPaymentRequest(this.currency,
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
        }

        public Payments.InvoicePayments.InvoicePaymentRequest BuildInvoiceRequest()
        {
            return new Payments.InvoicePayments.InvoicePaymentRequest(
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
        }

        public Payments.VippsPayments.VippsPaymentRequest BuildVippsRequest()
        {
            return new Payments.VippsPayments.VippsPaymentRequest(
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
        }

        public Payments.MobilePayPayments.MobilePayPaymentRequest BuildMobilePayRequest()
        {
            return new MobilePayPaymentRequest(
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
        }

        public Payments.TrustlyPayments.TrustlyPaymentRequest BuildTrustlyRequest()
        {
            return new Payments.TrustlyPayments.TrustlyPaymentRequest(
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

        public PaymentRequestBuilder WithCreditcardTestValues(Guid payeeId, Operation operation = null, Intent intent = Intent.Authorization)
        {
            this.operation = operation ?? Operation.Purchase;
            this.intent = intent;
            this.currency = new CurrencyCode("SEK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new CultureInfo("sv-SE");
            this.urls = new Urls(new List<Uri> { new Uri("https://example.com") }, new Uri("https://example.com/payment-completed"), new Uri("https://example.com/termsandconditoons.pdf"), new Uri("https://example.com/payment-canceled"));
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            this.generatePaymentToken = false;
            this.amount = Amount.FromDecimal(1600);
            this.vatAmount = Amount.FromDecimal(0);
            this.metadata = new Dictionary<string, object> { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };

            this.price = new List<Price>
            {
                new Price(this.amount, PriceType.CreditCard, this.vatAmount)
            };
            return this;
        }


        public PaymentRequestBuilder WithSwishTestValues(Guid payeeId)
        {
            this.operation = Operation.Purchase;
            this.intent = Intent.Sale;
            this.currency = new CurrencyCode("SEK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new CultureInfo("sv-SE");
            this.urls = new Urls(new List<Uri> { new Uri("https://example.com") }, new Uri("https://example.com/payment-completed"), new Uri("https://example.com/termsandconditoons.pdf"), new Uri("https://example.com/payment-canceled"));
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            this.prefillInfo = new PrefillInfo(new Msisdn("+46701234567"));
            this.generatePaymentToken = false;
            this.amount = Amount.FromDecimal(1600);
            this.vatAmount = Amount.FromDecimal(0);
            this.swish = new SwishPaymentOptionsObject();
            this.metadata = new Dictionary<string, object> { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            this.price = new List<Price>
            {
                new Price(this.amount, PriceType.Swish, this.vatAmount)
            };
            return this;
        }

        public PaymentRequestBuilder WithInvoiceTestValues(Guid payeeId, Operation operation = null)
        {
            this.operation = operation ?? Operation.FinancingConsumer;
            this.intent = Intent.Authorization;
            this.currency = new CurrencyCode("NOK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new CultureInfo("nb-NO");
            this.urls = new Urls(new List<Uri> { new Uri("https://example.com") }, new Uri("https://example.com/payment-completed"), new Uri("https://example.com/termsandconditoons.pdf"), new Uri("https://example.com/payment-canceled"));
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            this.generatePaymentToken = false;
            this.amount = Amount.FromDecimal(1600);
            this.vatAmount = Amount.FromDecimal(0);
            this.metadata = new Dictionary<string, object> { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            this.invoiceType = InvoiceType.PayExFinancingNO;
            this.price = new List<Price>
            {
                new Price(this.amount, PriceType.Invoice, this.vatAmount)
            };
            return this;
        }

        public PaymentRequestBuilder WithVippsTestValues(Guid payeeId, Operation operation = null, Intent intent = Intent.Authorization)
        {
            this.operation = operation ?? Operation.Purchase;
            this.intent = intent;
            this.currency = new CurrencyCode("NOK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new CultureInfo("nb-NO");
            this.urls = new Urls(new List<Uri> { new Uri("https://example.com") }, new Uri("https://example.com/payment-completed"), new Uri("https://example.com/termsandconditoons.pdf"), new Uri("https://example.com/payment-canceled"));
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            this.generatePaymentToken = false;
            this.amount = Amount.FromDecimal(1600);
            this.vatAmount = Amount.FromDecimal(0);
            this.metadata = new Dictionary<string, object> { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };

            this.price = new List<Price>
            {
                new Price(this.amount, PriceType.Vipps, this.vatAmount)
            };
            return this;
        }

        public PaymentRequestBuilder WithMobilePayTestValues(Guid payeeId)
        {
            this.operation = Operation.Purchase;
            this.intent = Intent.Authorization;
            this.currency = new CurrencyCode("SEK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new CultureInfo("sv-SE");
            this.urls = new Urls(new List<Uri> { new Uri("https://example.com") }, new Uri("https://example.com/payment-completed"), new Uri("https://example.com/termsandconditoons.pdf"), new Uri("https://example.com/payment-canceled"));
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString(), "payeeName", "productCategory");
            this.prefillInfo = new PrefillInfo(new Msisdn("+46701234567"));
            this.amount = Amount.FromDecimal(1600);
            this.vatAmount = Amount.FromDecimal(0);
            this.metadata = new Dictionary<string, object> { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            this.shopslogoUrl = new Uri("https://example.com");
            this.price = new List<Price>
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
            this.intent = Intent.Sale;
            this.currency = new CurrencyCode("SEK");
            this.description = "Test Purchase";
            this.payerReference = "SomeReference";
            this.userAgent = "Mozilla/5.0...";
            this.language = new CultureInfo("sv-SE");
            this.urls = new Urls(new List<Uri> { new Uri("https://example.com") }, new Uri("https://example.com/payment-completed"), new Uri("https://example.com/termsandconditoons.pdf"), new Uri("https://example.com/payment-canceled"), null, new Uri("https://example.com/payment-callback"));
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            this.amount = Amount.FromDecimal(1600);
            this.vatAmount = Amount.FromDecimal(0);
            this.metadata = new Dictionary<string, object> { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            this.price = new List<Price>
            {
                new Price(this.amount, PriceType.Trustly, this.vatAmount)
            };
            this.trustlyPrefillInfo = new Payments.TrustlyPayments.PrefillInfo("Ola", "Nordmann");
            return this;
        }
    }
}