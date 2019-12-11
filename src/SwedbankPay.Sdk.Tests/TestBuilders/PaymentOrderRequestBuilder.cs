namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    using SwedbankPay.Sdk.PaymentOrders;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SwedbankPay.Sdk.Payments;

    public class PaymentOrderRequestBuilder
    {
        private Operation operation;
        private CurrencyCode currency;
        private Amount amount;
        private Amount vatAmount;
        private string description;
        private string userAgent;
        private Language language;
        private bool generateRecurrenceToken;
        private Urls urls;
        private PayeeInfo payeeInfo;
        private List<OrderItem> orderItems;
        private Dictionary<string, object> metaData;

    public PaymentOrderRequestBuilder WithTestValues()
        {

            this.operation = Operation.Purchase;
            this.currency = new CurrencyCode("SEK");
            this.amount = Amount.FromDecimal(1700);
            this.vatAmount = Amount.FromDecimal(0);
            this.description = "Test Description";
            this.generateRecurrenceToken = false;
            this.urls = new Urls();
            this.userAgent = "useragent";
            this.language = new Language("sv-SE");
            this.payeeInfo = new PayeeInfo("91a4c8e0-72ac-425c-a687-856706f9e9a1",DateTime.Now.Ticks.ToString());
            return this;
        }
        public PaymentOrderRequestBuilder WithAmounts(long amount = 30000, long vatAmount = 7500)
        {
            if (amount - vatAmount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(vatAmount), $"{vatAmount} cant be greater than {amount}"); 
            }

            this.amount = Amount.FromDecimal(amount);
            this.vatAmount = Amount.FromDecimal(vatAmount);
           
            return this;
        }

        public PaymentOrderRequestBuilder WithOrderItems()
        {
            this.orderItems = new List<OrderItem>
            {
                new OrderItem("p1", "Product1", OrderItemType.Product, "ProductGroup1", 4, "pcs", Amount.FromDecimal(300), 0, Amount.FromDecimal(1200), Amount.FromDecimal(0), "https://example.com/products/123", "https://example.com/products/123.jpg"),
                new OrderItem("p2", "Product2", OrderItemType.Product, "ProductGroup1", 1, "pcs", Amount.FromDecimal(500), 0, Amount.FromDecimal(500), Amount.FromDecimal(0))
            };
            this.amount = Amount.FromDecimal(this.orderItems.Sum(s => Amount.ToDecimal(s.Amount)));
            this.vatAmount = Amount.FromDecimal(this.orderItems.Sum(s => Amount.ToDecimal(s.VatAmount)));

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
        public PaymentOrderRequestBuilder WithLanguageCode(string code)
        {
            this.language = new Language(code);
            return this;
        }


        public PaymentOrderRequest Build()
        {
            return new PaymentOrderRequest(this.operation, this.currency, this.amount, this.vatAmount, this.description, this.userAgent, this.language, this.generateRecurrenceToken, this.urls, this.payeeInfo, orderItems: this.orderItems);
        }
    }
}