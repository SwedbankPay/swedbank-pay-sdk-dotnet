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
                Amount = 1300,
                VatAmount = 0,
                Description = "Test Description",
                GenerateRecurrenceToken = false,
                UserAgent = "useragent",
                Language = PaymentOrderLanguage.Swedish,
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
                new OrderItem
                {
                    Reference = "p1",
                    Name = "Product1",
                    Type = "PRODUCT",
                    Class = "ProductGroup1",
                    ItemUrl = "https://example.com/products/123",
                    ImageUrl = "https://example.com/products/123.jpg",
                    Description = "Product 1 description",
                    DiscountDescription = "Volume discount",
                    Quantity = 4,
                    QuantityUnit = "pcs",
                    UnitPrice = 300,
                    DiscountPrice = 200,
                    VatPercent = 0,
                    Amount = 800,
                    VatAmount = 0
                },
                new OrderItem
                {
                    Reference = "p2",
                    Name = "Product2",
                    Type = "PRODUCT",
                    Class = "ProductGroup1",
                    Description = "Product 2 description",
                    DiscountDescription = "Volume discount",
                    Quantity = 1,
                    QuantityUnit = "pcs",
                    UnitPrice = 500,
                    VatPercent = 0,
                    Amount = 500,
                    VatAmount = 0
                }
            };
            this.paymentOrderRequest.Amount =
                this.paymentOrderRequest.OrderItems.Select(a => a.Amount).Sum();
            return this;
        }

        public PaymentOrderRequestBuilder WithVat()
        {
           this.paymentOrderRequest.VatAmount = (long?)(this.paymentOrderRequest.Amount * 0.25);

            return this;
        }

        public PaymentOrderRequest Build()
        {
            return this.paymentOrderRequest;
        }
    }
}