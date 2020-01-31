using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    public class PaymentOrderRequestBuilder
    {
        private Amount amount;
        private CurrencyCode currency;
        private string description;
        private bool generateRecurrenceToken;
        private CultureInfo language;
        private Dictionary<string, object> metaData;
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
                                           orderItems: orderItems, metaData: metaData);
        }


        public PaymentOrderRequestBuilder WithAmounts(long amount = 30000, long vatAmount = 7500)
        {
            if (amount - vatAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(vatAmount), $"{vatAmount} cant be greater than {amount}");

            this.amount = Amount.FromDecimal(amount);
            this.vatAmount = Amount.FromDecimal(vatAmount);

            return this;
        }


        public PaymentOrderRequestBuilder WithLanguageCode(string code)
        {
            language = new CultureInfo(code);
            return this;
        }


        public PaymentOrderRequestBuilder WithMetaData()
        {
            metaData = new Dictionary<string, object>
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
                new OrderItem("p1", "Product1", OrderItemType.Product, "ProductGroup1", 4, "pcs", Amount.FromDecimal(300), 0,
                              Amount.FromDecimal(1200), Amount.FromDecimal(0), "https://example.com/products/123",
                              "https://example.com/products/123.jpg"),
                new OrderItem("p2", "Product2", OrderItemType.Product, "ProductGroup1", 1, "pcs", Amount.FromDecimal(500), 0,
                              Amount.FromDecimal(500), Amount.FromDecimal(0))
            };
            amount = Amount.FromDecimal(orderItems.Sum(s => Amount.ToDecimal(s.Amount)));
            vatAmount = Amount.FromDecimal(orderItems.Sum(s => Amount.ToDecimal(s.VatAmount)));

            return this;
        }


        public PaymentOrderRequestBuilder WithTestValues()
        {
            operation = Operation.Purchase;
            currency = new CurrencyCode("SEK");
            amount = Amount.FromDecimal(1700);
            vatAmount = Amount.FromDecimal(0);
            description = "Test Description";
            generateRecurrenceToken = false;
            urls = new Urls(new List<Uri> { new Uri("https://example.com") }, new Uri("https://example.com/payment-completed"), new Uri("https://example.com/termsandconditoons.pdf"), new Uri("https://example.com/payment-canceled"));
            userAgent = "useragent";
            language = new CultureInfo("sv-SE");
            payeeInfo = new PayeeInfo(Guid.Parse("91a4c8e0-72ac-425c-a687-856706f9e9a1"), DateTime.Now.Ticks.ToString());
            metaData = new Dictionary<string, object> { { "key1", "value1" }, { "key2", 2 }, { "key3", 3.1 }, { "key4", false } };
            return this;
        }
    }
}