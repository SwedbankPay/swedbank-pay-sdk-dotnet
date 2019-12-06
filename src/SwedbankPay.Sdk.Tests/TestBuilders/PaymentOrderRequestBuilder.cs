namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    using SwedbankPay.Sdk.PaymentOrders;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SwedbankPay.Sdk.Payments;

    public class PaymentOrderRequestBuilder
    {
        private PaymentOrderRequest paymentOrderRequest = new PaymentOrderRequest();

        public PaymentOrderRequestBuilder WithTestValues()
        {

            this.paymentOrderRequest = new PaymentOrderRequest
            {
                Currency = new CurrencyCode("SEK"),
                Amount = Amount.FromDecimal(1700),
                VatAmount = Amount.FromDecimal(0),
                Description = "Test Description",
                GenerateRecurrenceToken = false,
                UserAgent = "useragent",
                Language = new Language("sv-SE"),
                PayeeInfo = new PayeeInfo
                {
                    PayeeId = "91a4c8e0-72ac-425c-a687-856706f9e9a1",
                    PayeeReference = DateTime.Now.Ticks.ToString()
                }
            };

            return this;

        }

        public PaymentOrderRequestBuilder WithOrderItems()
        {
            this.paymentOrderRequest.OrderItems = new List<OrderItem>
            {
                new OrderItem("p1", "Product1", OrderItemType.Product, "ProductGroup1", 4, "pcs", Amount.FromDecimal(300), 0, Amount.FromDecimal(1200), Amount.FromDecimal(0), "https://example.com/products/123", "https://example.com/products/123.jpg"),
                new OrderItem("p2", "Product2", OrderItemType.Product, "ProductGroup1", 1, "pcs", Amount.FromDecimal(500), 0, Amount.FromDecimal(500), Amount.FromDecimal(0))
            };
            this.paymentOrderRequest.Amount = Amount.FromDecimal(this.paymentOrderRequest.OrderItems.Select(a => a.Amount.Value).Sum());

            return this;
        }

        public PaymentOrderRequest Build()
        {
            return this.paymentOrderRequest;
        }
    }
}