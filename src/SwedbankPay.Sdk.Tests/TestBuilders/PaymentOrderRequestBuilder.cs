using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    public class PaymentOrderRequestBuilder
    {
        private Amount amount;
        private Currency currency;
        private string description;
        private bool generateRecurrenceToken;
        private Language language;
        private Dictionary<string, object> metadata;
        private Operation operation;
        private List<OrderItem> orderItems;
        private PayeeInfo payeeInfo;
        private Urls urls;
        private string userAgent;
        private Amount vatAmount;


        public PaymentOrderRequest Build()
        {
            return new PaymentOrderRequest(this.operation, this.currency, this.amount, this.vatAmount, this.description, this.userAgent, this.language, this.generateRecurrenceToken, this.urls, this.payeeInfo,
                                           orderItems: this.orderItems, metadata: this.metadata);
        }


        public PaymentOrderRequestBuilder WithAmounts(long longAmount = 30000, long longVatAmount = 7500)
        {
            if (longAmount - longVatAmount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(longVatAmount), $"{longVatAmount} cant be greater than {longAmount}");
            }

            this.amount = new Amount(longAmount);
            this.vatAmount = new Amount(longVatAmount);

            return this;
        }


        public PaymentOrderRequestBuilder WithLanguageCode(string code)
        {
            this.language = new Language(code);
            return this;
        }


        public PaymentOrderRequestBuilder WithMetadata()
        {
            this.metadata = new Dictionary<string, object>
            {
                ["testvalue"] = 3,
                ["testvalue2"] = "test"
            };
            return this;
        }


        public PaymentOrderRequestBuilder WithOrderItems()
        {
            this.orderItems = new List<OrderItem>
            {
                new OrderItem("p1", "Product1", OrderItemType.Product, "ProductGroup1", 4, "pcs", new Amount(300), 0,
                              new Amount(1200), new Amount(0), "https://example.com/products/123",
                              "https://example.com/products/123.jpg"),
                new OrderItem("p2", "Product2", OrderItemType.Product, "ProductGroup1", 1, "pcs", new Amount(500), 0,
                              new Amount(500), new Amount(0))
            };
            this.amount = new Amount(this.orderItems.Sum(s => s.Amount));
            this.vatAmount = new Amount(this.orderItems.Sum(s => s.VatAmount));

            return this;
        }


        public PaymentOrderRequestBuilder WithTestValues(Guid payeeId)
        {
            this.operation = Operation.Purchase;
            this.currency = new Currency("SEK");
            this.amount = new Amount(1700);
            this.vatAmount = new Amount(0);
            this.description = "Test Description";
            this.generateRecurrenceToken = false;
            this.urls = new Urls(new UrlsDto
            {
                HostUrls = new List<Uri> { new Uri("https://example.com") },
                CompleteUrl = new Uri("https://example.com/payment-completed"),
                TermsOfServiceUrl = new Uri("https://example.com/termsandconditoons.pdf"),
                CancelUrl = new Uri("https://example.com/payment-canceled")
            });
            this.userAgent = "useragent";
            this.language = new Language("sv-SE");
            this.payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            this.metadata = new Dictionary<string, object> { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            return this;
        }
    }
}