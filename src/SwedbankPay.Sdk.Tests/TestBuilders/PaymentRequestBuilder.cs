using SwedbankPay.Sdk.Payments;
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
        private bool generatePaymentToken;
        private Amount amount;
        private Amount vatAmount;
        private string payerReference;
        private SwishPaymentOptionsObject swish;
        private List<Price> price;
        private Dictionary<string, object> metaData;


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
                generatePaymentToken: this.generatePaymentToken, generateReccurenceToken: false, payerReference: this.payerReference, riskIndicator: null, metaData: this.metaData);
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
                                      metaData: this.metaData
            );
        }

    public Payments.VippsPayments.PaymentRequest BuildVippsRequest()
        {
            return new Payments.VippsPayments.PaymentRequest(
                this.operation,
                this.intent,
                this.currency,
                this.price,
                this.description,
                this.userAgent,
                this.language,
                this.urls,
                this.payeeInfo);
        }

        public PaymentRequestBuilder WithVippsTestValues(Operation operation = null, Intent intent = Intent.Authorization)
        {
            this.operation = operation ?? Operation.Purchase;
            this.intent = intent;
            this.currency = new CurrencyCode("NOK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new CultureInfo("nb-NO");
            this.urls = new Urls(new List<Uri> { new Uri("https://example.com") }, new Uri("https://example.com/payment-completed"), new Uri("https://example.com/termsandconditoons.pdf"), new Uri("https://example.com/payment-canceled"));
            this.payeeInfo = new PayeeInfo(Guid.Parse("91a4c8e0-72ac-425c-a687-856706f9e9a1"), DateTime.Now.Ticks.ToString());
            this.generatePaymentToken = false;
            this.amount = Amount.FromDecimal(1600);
            this.vatAmount = Amount.FromDecimal(0);
            this.metaData = new Dictionary<string, object> { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };

            this.price = new List<Price>
            {
                new Price(this.amount, PriceType.Vipps, this.vatAmount)
            };
            return this;
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
            this.metaData = new Dictionary<string, object> { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };

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
            this.metaData = new Dictionary<string, object> { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };

            this.price = new List<Price>
            {
                new Price(this.amount, PriceType.Swish, this.vatAmount)
            };
            return this;
        }
    }
}
