using System;
using System.Collections.Generic;
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
        private Language language;
        private Dictionary<string, object> metaData;
        private Operation operation;
        private List<OrderItem> orderItems;
        private PayeeInfo payeeInfo;
        private Urls urls;
        private string userAgent;
        private Amount vatAmount;


        public PaymentOrderRequest Build()
        {
            return new PaymentOrderRequest(this.operation, this.currency, this.amount, this.vatAmount, this.description, this.userAgent,
                                           this.language, this.generateRecurrenceToken, this.urls, this.payeeInfo,
                                           orderItems : this.orderItems);
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
            this.language = new Language(code);
            return this;
        }


        public PaymentOrderRequestBuilder WithMetaData()
        {
            this.metaData = new Dictionary<string, object>
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
                new OrderItem("p1", "Product1", OrderItemType.Product, "ProductGroup1", 4, "pcs", Amount.FromDecimal(300), 0,
                              Amount.FromDecimal(1200), Amount.FromDecimal(0), "https://example.com/products/123",
                              "https://example.com/products/123.jpg"),
                new OrderItem("p2", "Product2", OrderItemType.Product, "ProductGroup1", 1, "pcs", Amount.FromDecimal(500), 0,
                              Amount.FromDecimal(500), Amount.FromDecimal(0))
            };
            this.amount = Amount.FromDecimal(this.orderItems.Sum(s => Amount.ToDecimal(s.Amount)));
            this.vatAmount = Amount.FromDecimal(this.orderItems.Sum(s => Amount.ToDecimal(s.VatAmount)));

            return this;
        }


        public PaymentOrderRequestBuilder WithTestValues()
        {
            this.operation = Operation.Purchase;
            this.currency = new CurrencyCode("SEK");
            this.amount = Amount.FromDecimal(1700);
            this.vatAmount = Amount.FromDecimal(0);
            this.description = "Test Description";
            this.generateRecurrenceToken = false;
            this.urls = new Urls(new List<Uri>{ new Uri("https://example.com") },new Uri("https://example.com/payment-completed"),new Uri("https://example.com/termsandconditoons.pdf"), new Uri("https://example.com/payment-canceled"));
            this.userAgent = "useragent";
            this.language = new Language("sv-SE");
            this.payeeInfo = new PayeeInfo("91a4c8e0-72ac-425c-a687-856706f9e9a1", DateTime.Now.Ticks.ToString());
            return this;
        }
    }
}