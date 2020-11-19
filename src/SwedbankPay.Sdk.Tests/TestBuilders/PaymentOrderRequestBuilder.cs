using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    public class PaymentOrderRequestBuilder
    {
        private Amount amount;
        private CurrencyCode currency;
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
            return new PaymentOrderRequest(operation, currency, amount, vatAmount, description, userAgent,
                                           language, generateRecurrenceToken, urls, payeeInfo,
                                           orderItems: orderItems, metadata: metadata);
        }


        public PaymentOrderRequestBuilder WithAmounts(long longAmount = 30000, long longVatAmount = 7500)
        {
            if (longAmount - longVatAmount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(longVatAmount), $"{longVatAmount} cant be greater than {longAmount}");
            }

            amount = new Amount(longAmount);
            vatAmount = new Amount(longVatAmount);

            return this;
        }


        public PaymentOrderRequestBuilder WithLanguageCode(string code)
        {
            language = new Language(code);
            return this;
        }


        public PaymentOrderRequestBuilder WithMetadata()
        {
            metadata = new Dictionary<string, object>
            {
                ["testvalue"] = 3,
                ["testvalue2"] = "test"
            };
            return this;
        }


        public PaymentOrderRequestBuilder WithOrderItems()
        {
            orderItems = new List<OrderItem>
            {
                new OrderItem("p1", "Product1", OrderItemType.Product, "ProductGroup1", 4, "pcs", new Amount(300), 0,
                              new Amount(1200), new Amount(0), "https://example.com/products/123",
                              "https://example.com/products/123.jpg"),
                new OrderItem("p2", "Product2", OrderItemType.Product, "ProductGroup1", 1, "pcs", new Amount(500), 0,
                              new Amount(500), new Amount(0))
            };
            amount = new Amount(orderItems.Sum(s => s.Amount));
            vatAmount = new Amount(orderItems.Sum(s => s.VatAmount));

            return this;
        }


        public PaymentOrderRequestBuilder WithTestValues(Guid payeeId)
        {
            operation = Operation.Purchase;
            currency = new CurrencyCode("SEK");
            amount = new Amount(1700);
            vatAmount = new Amount(0);
            description = "Test Description";
            generateRecurrenceToken = false;
            urls = new Urls(new UrlsDto
            {
                HostUrls = new List<Uri> { new Uri("https://example.com") },
                CompleteUrl = new Uri("https://example.com/payment-completed"),
                TermsOfServiceUrl = new Uri("https://example.com/termsandconditoons.pdf"),
                CancelUrl = new Uri("https://example.com/payment-canceled")
            });
            userAgent = "useragent";
            language = new Language("sv-SE");
            payeeInfo = new PayeeInfo(payeeId, DateTime.Now.Ticks.ToString());
            metadata = new Dictionary<string, object> { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            return this;
        }
    }
}