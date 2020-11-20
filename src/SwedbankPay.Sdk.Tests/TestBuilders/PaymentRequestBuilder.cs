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
        private Urls urls;
        private PayeeInfo payeeInfo;
        private PrefillInfo prefillInfo;
        private TrustlyPrefillInfo trustlyPrefillInfo;
        private bool generatePaymentToken;
        private Amount amount;
        private Amount vatAmount;
        private string payerReference;
        private List<IPrice> price;
        private MetadataResponse metadata;
        private InvoiceType invoiceType;
        private Uri shopslogoUrl;


        public CardPaymentRequest BuildCreditardPaymentRequest()
        {
            return new CardPaymentRequest(
                operation,
                intent,
                currency,
                price,
                description,
                userAgent,
                language,
                urls,
                payeeInfo,
                generatePaymentToken: generatePaymentToken, GenerateRecurrenceToken: false, payerReference: payerReference, riskIndicator: null, metadata: metadata);
        }

        public SwishPaymentRequest BuildSwishPaymentRequest() => new SwishPaymentRequest(price,
                                      description,
                                      payerReference,
                                      userAgent,
                                      language,
                                      urls,
                                      payeeInfo,
                                      prefillInfo,
                                      metadata: metadata
            );

        public InvoicePaymentRequest BuildInvoiceRequest() => new InvoicePaymentRequest(
                operation,
                intent,
                currency,
                price,
                description,
                userAgent,
                language,
                urls,
                payeeInfo,
                invoiceType);

        public VippsPaymentRequest BuildVippsRequest() => new VippsPaymentRequest(
                operation,
                intent,
                currency,
                price,
                description,
                userAgent,
                language,
                urls,
                payeeInfo,
                payerReference,
                generatePaymentToken,
                false,
                metadata);

        public MobilePayPaymentRequest BuildMobilePayRequest() => new MobilePayPaymentRequest(
                operation,
                intent,
                currency,
                price,
                description,
                userAgent,
                language,
                urls,
                payeeInfo,
                shopslogoUrl);

        public TrustlyPaymentRequest BuildTrustlyRequest()
        {
            return new TrustlyPaymentRequest(
                currency,
                price,
                description,
                payerReference,
                userAgent,
                language,
                urls,
                payeeInfo,
                trustlyPrefillInfo);
        }

        public PaymentRequestBuilder WithCreditcardTestValues(Guid payeeId, Operation testOperation = null, PaymentIntent paymentIntent = PaymentIntent.Authorization)
        {
            operation = testOperation ?? Operation.Purchase;
            intent = paymentIntent;
            currency = new Currency("SEK");
            description = "Test Description";
            payerReference = "AB1234";
            userAgent = "useragent";
            language = new Language("sv-SE");
            SetUrls();
            payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            generatePaymentToken = false;
            amount = new Amount(1600);
            vatAmount = new Amount(0);
            metadata = new MetadataResponse { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            price = new List<IPrice>
            {
                new Price(amount, PriceType.CreditCard, vatAmount)
            };

            return this;
        }


        public PaymentRequestBuilder WithSwishTestValues(Guid payeeId)
        {
            operation = Operation.Purchase;
            intent = PaymentIntent.Sale;
            currency = new Currency("SEK");
            description = "Test Description";
            payerReference = "AB1234";
            userAgent = "useragent";
            language = new Language("sv-SE");
            SetUrls();
            payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            prefillInfo = new PrefillInfo(new Msisdn("+46701234567"));
            generatePaymentToken = false;
            amount = new Amount(1600);
            vatAmount = new Amount(0);
            metadata = new MetadataResponse { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            price = new List<IPrice>
            {
                new Price(amount, PriceType.Swish, vatAmount)
            };
            return this;
        }

        public PaymentRequestBuilder WithInvoiceTestValues(Guid payeeId, Operation testOperation = null)
        {
            operation = testOperation ?? Operation.FinancingConsumer;
            intent = PaymentIntent.Authorization;
            currency = new Currency("NOK");
            description = "Test Description";
            payerReference = "AB1234";
            userAgent = "useragent";
            language = new Language("nb-NO");
            SetUrls();
            payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            generatePaymentToken = false;
            amount = new Amount(1600);
            vatAmount = new Amount(0);
            metadata = new MetadataResponse { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            invoiceType = InvoiceType.PayExFinancingNO;
            price = new List<IPrice>
            {
                new Price(amount, PriceType.Invoice, vatAmount)
            };
            return this;
        }

        public PaymentRequestBuilder WithVippsTestValues(Guid payeeId, Operation testOperation = null)
        {
            operation = testOperation ?? Operation.Purchase;
            intent = PaymentIntent.Authorization;
            currency = new Currency("NOK");
            description = "Test Description";
            payerReference = "AB1234";
            userAgent = "useragent";
            language = new Language("nb-NO");
            SetUrls();
            payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            generatePaymentToken = false;
            amount = new Amount(1600);
            vatAmount = new Amount(0);
            metadata = new MetadataResponse { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };

            price = new List<IPrice>
            {
                new Price(amount, PriceType.Vipps, vatAmount)
            };
            return this;
        }

        public PaymentRequestBuilder WithMobilePayTestValues(Guid payeeId)
        {
            operation = Operation.Purchase;
            intent = PaymentIntent.Authorization;
            currency = new Currency("SEK");
            description = "Test Description";
            payerReference = "AB1234";
            userAgent = "useragent";
            language = new Language("sv-SE");
            SetUrls();
            payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString(), "payeeName", "productCategory");
            prefillInfo = new PrefillInfo(new Msisdn("+46701234567"));
            amount = new Amount(1600);
            vatAmount = new Amount(0);
            metadata = new MetadataResponse { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            shopslogoUrl = new Uri("https://example.com");
            price = new List<IPrice>
            {
                new Price(amount, PriceType.Visa, vatAmount)
            };
            return this;
        }


        public PaymentRequestBuilder WithTruslyTestValues(Guid payeeId)
        {
            return WithTruslyTestValues(payeeId, Operation.Purchase);
        }


        public PaymentRequestBuilder WithTruslyTestValues(Guid payeeId, Operation testOperation)
        {
            operation = testOperation ?? Operation.Purchase;
            intent = PaymentIntent.Sale;
            currency = new Currency("SEK");
            description = "Test Purchase";
            payerReference = "SomeReference";
            userAgent = "Mozilla/5.0...";
            language = new Language("sv-SE");
            SetUrls();
            payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            amount = new Amount(1600);
            vatAmount = new Amount(0);
            metadata = new MetadataResponse { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            price = new List<IPrice>
            {
                new Price(amount, PriceType.Trustly, vatAmount)
            };
            trustlyPrefillInfo = new TrustlyPrefillInfo("Ola", "Nordmann");
            return this;
        }

        private void SetUrls()
        {
            urls = new Urls(new UrlsDto
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