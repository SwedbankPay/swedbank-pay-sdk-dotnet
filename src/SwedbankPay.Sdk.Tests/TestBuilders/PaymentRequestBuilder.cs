using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Payments.Swish;

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
        private readonly bool generateReccurrenceToken;
        private Amount amount;
        private Amount vatAmount;
        private string payerReference;
        private SwishRequest swish;
        private List<Price> price;
        private Dictionary<string, object> metaData;


        public Payments.Card.PaymentRequest BuildCreditardPaymentRequest()
        {
            return new Payments.Card.PaymentRequest(
                operation,
                intent,
                currency,
                price,
                description,
                userAgent,
                language,
                urls,
                payeeInfo,
                generatePaymentToken: generatePaymentToken, generateReccurenceToken: generateReccurrenceToken, payerReference: payerReference, riskIndicator: null, metaData: metaData);
        }

        public PaymentRequest BuildSwishPaymentRequest()
        {
            return new PaymentRequest(currency,
                                      price,
                                      description,
                                      payerReference,
                                      userAgent,
                                      language,
                                      urls,
                                      payeeInfo,
                                      prefillInfo,
                                      swish,
                                      metaData

            );
        }


        public PaymentRequestBuilder WithCreditcardTestValues(Operation operation = null, Intent intent = Intent.Authorization)
        {
            this.operation = operation ?? Operation.Purchase;
            this.intent = intent;
            currency = new CurrencyCode("SEK");
            description = "Test Description";
            payerReference = "AB1234";
            userAgent = "useragent";
            language = new CultureInfo("sv-SE");
            urls = new Urls(new List<Uri> { new Uri("https://example.com") }, new Uri("https://example.com/payment-completed"), new Uri("https://example.com/termsandconditoons.pdf"), new Uri("https://example.com/payment-canceled"));
            payeeInfo = new PayeeInfo(Guid.Parse("91a4c8e0-72ac-425c-a687-856706f9e9a1"), DateTime.Now.Ticks.ToString());
            generatePaymentToken = false;
            amount = Amount.FromDecimal(1600);
            vatAmount = Amount.FromDecimal(0);
            metaData = new Dictionary<string, object> { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };

            price = new List<Price>
            {
                new Price(amount, PriceType.CreditCard, vatAmount)
            };
            return this;
        }


        public PaymentRequestBuilder WithSwishTestValues()
        {
            operation = Operation.Purchase;
            intent = Intent.Sale;
            currency = new CurrencyCode("SEK");
            description = "Test Description";
            payerReference = "AB1234";
            userAgent = "useragent";
            language = new CultureInfo("sv-SE");
            urls = new Urls(new List<Uri> { new Uri("https://example.com") }, new Uri("https://example.com/payment-completed"), new Uri("https://example.com/termsandconditoons.pdf"), new Uri("https://example.com/payment-canceled"));
            payeeInfo = new PayeeInfo(Guid.Parse("91a4c8e0-72ac-425c-a687-856706f9e9a1"), DateTime.Now.Ticks.ToString());
            prefillInfo = new PrefillInfo(new Msisdn("+46701234567"));
            generatePaymentToken = false;
            amount = Amount.FromDecimal(1600);
            vatAmount = Amount.FromDecimal(0);
            swish = new SwishRequest();
            metaData = new Dictionary<string, object> { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };

            price = new List<Price>
            {
                new Price(amount, PriceType.Swish, vatAmount)
            };
            return this;
        }
    }
}
