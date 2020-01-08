using System;
using System.Collections.Generic;

using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Payments.Swish;

namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    public class PaymentRequestBuilder
    {
        private Operation operation;
        private string intent;
        private CurrencyCode currency;
        private string description;
        private string userAgent;
        private Language language;
        private Urls urls;
        private PayeeInfo payeeInfo;
        private PrefillInfo prefillInfo;
        private bool generatePaymentToken;
        private Amount amount;
        private Amount vatAmount;
        private string payerReference;
        private SwishRequest swish;
        private List<Price> price;


        public Payments.Card.PaymentRequest BuildCreditardPaymentRequest()
        {
            return null;
        }

        public Payments.Swish.PaymentRequest BuildSwishPaymentRequest()
        {
            return new SwedbankPay.Sdk.Payments.Swish.PaymentRequest(this.currency,
                                      this.price,
                                      this.description,
                                      this.payerReference,
                                      this.userAgent,
                                      this.language,
                                      this.urls,
                                      this.payeeInfo,
                                      this.prefillInfo,
                                      this.swish

            );
        }


        public PaymentRequestBuilder WithTestValues()
        {
            this.price = new List<Price>
            {
                new Price(Amount.FromInt(1600), PriceType.Swish, Amount.FromInt(0))
            };
            this.operation = Operation.Purchase;
            this.intent = "Sale";
            this.currency = new CurrencyCode("SEK");
            this.description = "Test Description";
            this.payerReference = "AB1234";
            this.userAgent = "useragent";
            this.language = new Language("sv-SE");
            this.urls = new Urls(new List<Uri> { new Uri("https://example.com") }, new Uri("https://example.com/payment-completed"), new Uri("https://example.com/termsandconditoons.pdf"), new Uri("https://example.com/payment-canceled"));
            this.payeeInfo = new PayeeInfo("91a4c8e0-72ac-425c-a687-856706f9e9a1", DateTime.Now.Ticks.ToString());
            this.prefillInfo = new PrefillInfo(new Msisdn("+46701234567"));
            this.generatePaymentToken = false;
            this.amount = Amount.FromDecimal(1600);
            this.vatAmount = Amount.FromDecimal(0);
            this.swish = new SwishRequest();
            return this;
        }
    }
}
