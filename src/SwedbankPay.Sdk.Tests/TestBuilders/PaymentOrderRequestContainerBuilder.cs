namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    using SwedbankPay.Sdk.PaymentOrders;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PaymentOrderRequestContainerBuilder
    {
        private PaymentOrderRequestContainer paymentOrderRequestContainer = new PaymentOrderRequestContainer();

        public PaymentOrderRequestContainerBuilder WithTestValues()
        {

            this.paymentOrderRequestContainer.Paymentorder = new PaymentOrderRequest
            {
                Currency = "SEK",
                Amount = 1300,
                VatAmount = 0,
                Description = "Test Description",
                GenerateRecurrenceToken = false,
                UserAgent = "useragent",
                Language = "sv-SE",
                Urls = new Urls
                {
                    TermsOfServiceUrl = null,
                    CallbackUrl = null,
                    CancelUrl = "https://payex.eu.ngrok.io/payment-canceled?orderGroupId={orderGroupId}",
                    CompleteUrl =
                        "https://payex.eu.ngrok.io/sv/checkout-sv/PayexCheckoutConfirmation/?orderGroupId={orderGroupId}",
                    LogoUrl = null,
                    HostUrls = new List<string> {{"https://payex.eu.ngrok.io"}}
                },
                PayeeInfo = new PayeeInfo
                {
                    PayeeId = "91a4c8e0-72ac-425c-a687-856706f9e9a1", PayeeReference = DateTime.Now.Ticks.ToString()
                }
            };

            return this;
            
        }

        public PaymentOrderRequestContainerBuilder WithOrderItems()
        {
            this.paymentOrderRequestContainer.Paymentorder.OrderItems = new List<OrderItem>
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
            this.paymentOrderRequestContainer.Paymentorder.Amount =
                this.paymentOrderRequestContainer.Paymentorder.OrderItems.Select(a => a.Amount).Sum();
            return this;
        }

        public PaymentOrderRequestContainerBuilder WithVat()
        {
            //if (_paymentOrderRequestContainer.Paymentorder.OrderItems.Any())
            //{

            //}

            this.paymentOrderRequestContainer.Paymentorder.VatAmount = (long?) (this.paymentOrderRequestContainer.Paymentorder.Amount * 0.25);

            
            return this;
        }

        public PaymentOrderRequestContainer Build()
        {
            return this.paymentOrderRequestContainer;
        }
    }
}