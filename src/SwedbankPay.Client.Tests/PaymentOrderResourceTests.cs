namespace SwedbankPay.Client.Tests
{
    using SwedbankPay.Client.Exceptions;
    using SwedbankPay.Client.Models;
    using SwedbankPay.Client.Models.Common;
    using SwedbankPay.Client.Models.Request;
    using SwedbankPay.Client.Models.Request.Transaction;

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Xunit;

    public class PaymentOrderResourceTests : ResourceTestsBase
    {

        [Fact]
        public async Task CreatePaymentOrder_ShouldReturnPaymentOrderWithCorrectAmount()
        {
            var paymentOrderRequestContainer = CreatePaymentOrderRequestContainer();
            var paymentOrderResponseContainer = await _sut.PaymentOrders.CreatePaymentOrder(paymentOrderRequestContainer, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrderResponseContainer);
            Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);
            Assert.Equal(30000, paymentOrderResponseContainer.PaymentOrder.Amount);
        }


        [Fact]
        public async Task CreateAndGetPaymentOrder_ShouldReturnPaymentOrderWithSameAmount()
        {
            var paymentOrderRequestContainer = CreatePaymentOrderRequestContainer();
            var paymentOrderResponseContainer = await _sut.PaymentOrders.CreatePaymentOrder(paymentOrderRequestContainer, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrderResponseContainer);
            Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);
            var amount = paymentOrderResponseContainer.PaymentOrder.Amount;

            var paymentOrderResponseContainer2 = await _sut.PaymentOrders.GetPaymentOrder(paymentOrderResponseContainer.PaymentOrder.Id);
            Assert.NotNull(paymentOrderResponseContainer2);
            Assert.NotNull(paymentOrderResponseContainer2.PaymentOrder);
            Assert.Equal(amount, paymentOrderResponseContainer2.PaymentOrder.Amount);
        }


        [Fact]
        public async Task CreateAndUpdateOnlyAmountOnPaymentOrder_ShouldThrowCouldNotUpdatePaymentOrderException()
        {
            var paymentOrderRequestContainer = CreatePaymentOrderRequestContainer(30000, 7500);
            var paymentOrderResponseContainer = await _sut.PaymentOrders.CreatePaymentOrder(paymentOrderRequestContainer, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrderResponseContainer);
            Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);
            var amount = paymentOrderResponseContainer.PaymentOrder.Amount;

            var newAmount = 50000;
            var orderRequestContainer = new PaymentOrderRequestContainer
            {
                Paymentorder = new PaymentOrderRequest
                {
                    Amount = newAmount,
                }
            };

            await Assert.ThrowsAsync<CouldNotUpdatePaymentOrderException>(() => _sut.PaymentOrders.UpdatePaymentOrder(paymentOrderResponseContainer.PaymentOrder.Id, orderRequestContainer));
        }


        [Fact]
        public async Task CreateAndUpdatePaymentOrder_ShouldReturnPaymentOrderWithNewAmounts()
        {
            var paymentOrderRequestContainer = CreatePaymentOrderRequestContainer();
            var paymentOrderResponseContainer = await _sut.PaymentOrders.CreatePaymentOrder(paymentOrderRequestContainer, PaymentOrderExpand.All);
            Assert.NotNull(paymentOrderResponseContainer);
            Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);
            var amount = paymentOrderResponseContainer.PaymentOrder.Amount;

            var newAmount = 50000;
            var newVatAmount = 10000;
            var orderRequestContainer = new PaymentOrderRequestContainer
            {
                Paymentorder = new PaymentOrderRequest
                {
                    Amount = newAmount,
                    VatAmount = newVatAmount
                }
            };

            var paymentOrderResponseContainer2 = await _sut.PaymentOrders.UpdatePaymentOrder(paymentOrderResponseContainer.PaymentOrder.Id, orderRequestContainer);
            Assert.NotNull(paymentOrderResponseContainer2);
            Assert.NotNull(paymentOrderResponseContainer2.PaymentOrder);
            Assert.Equal(newAmount, paymentOrderResponseContainer2.PaymentOrder.Amount);
            Assert.Equal(newVatAmount, paymentOrderResponseContainer2.PaymentOrder.VatAmount);
        }

        [Fact]
        public async Task CreateAndCancelPaymentOrder_ShouldThrowNotYetAuthorizedException()
        {
            var paymentOrderRequestContainer = CreatePaymentOrderRequestContainer();
            var paymentOrderResponseContainer = await _sut.PaymentOrders.CreatePaymentOrder(paymentOrderRequestContainer, PaymentOrderExpand.All);

            Assert.NotNull(paymentOrderResponseContainer);
            Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);

            var transactionRequestContainer = new TransactionRequestContainer(new TransactionRequest
            {
                Description = "ABC123",
                PayeeReference = "Cancelling parts of the total amount"
            });

            await Assert.ThrowsAsync<PaymentNotYetAuthorizedException>(() => _sut.PaymentOrders.CancelPaymentOrder(paymentOrderResponseContainer.PaymentOrder.Id, transactionRequestContainer));
        }

        [Fact]
        public async Task CreateAndAbortPaymentOrder_ShouldReturnAbortedState()
        {
            var paymentOrderRequestContainer = CreatePaymentOrderRequestContainer();
            var paymentOrderResponseContainer = await _sut.PaymentOrders.CreatePaymentOrder(paymentOrderRequestContainer, PaymentOrderExpand.All);

            Assert.NotNull(paymentOrderResponseContainer);
            Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);

            var orderResponseContainer = await _sut.PaymentOrders.AbortPaymentOrder(paymentOrderResponseContainer.PaymentOrder.Id);
            Assert.NotNull(orderResponseContainer);
            Assert.NotNull(orderResponseContainer.PaymentOrder);
            Assert.Equal("Aborted", orderResponseContainer.PaymentOrder.State);
        }

        [Fact]
        public async Task CreateAndCapturePaymentOrder_ShouldThrowNotYetAuthorizedException()
        {
            var paymentOrderRequestContainer = CreatePaymentOrderRequestContainer(100000, 25000);
            var paymentOrderResponseContainer = await _sut.PaymentOrders.CreatePaymentOrder(paymentOrderRequestContainer, PaymentOrderExpand.All);

            Assert.NotNull(paymentOrderResponseContainer);
            Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);

            var transactionRequest = new TransactionRequest
            {
                Amount = 10000,
                Description = "Description",
                PayeeReference = Guid.NewGuid().ToString(),
                VatAmount = 2500,
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Reference = "p1",
                        Name = "Product1",
                        Type = "Product",
                        Class = "ProductGroup1",
                        ItemUrl = "https://example.com/products/123",
                        ImageUrl = "https://example.com/products/123.jpg",
                        Description = "Product 1 description",
                        DiscountDescription = "Volume discount",
                        Quantity = 4,
                        QuantityUnit = "pcs",
                        UnitPrice = 300,
                        DiscountPrice = 200,
                        VatPercent = 2500,
                        Amount = 1000,
                        VatAmount = 250
                    },
                    new OrderItem
                    {
                        Reference = "p2",
                        Name = "Product2",
                        Type = "Product",
                        Class = "ProductGroup1",
                        Description = "Product 2 description",
                        DiscountDescription = "Volume discount",
                        Quantity = 1,
                        QuantityUnit = "pcs",
                        UnitPrice = 500,
                        VatPercent = 2500,
                        Amount = 500,
                        VatAmount = 125
                    }
                }
            };
            var transactionRequestContainer = new TransactionRequestContainer(transactionRequest);
            await Assert.ThrowsAsync<PaymentNotYetAuthorizedException>(() => _sut.PaymentOrders.Capture(paymentOrderResponseContainer.PaymentOrder.Id, transactionRequestContainer));
        }

        [Fact]
        public async Task GetUnknownPaymentOrder_ShouldThrowCouldNotFindPaymentException()
        {
            var id = "/psp/paymentorders/56a45c8a-9605-437a-fb80-08d742822747";
            await Assert.ThrowsAsync<CouldNotFindPaymentException>(() => _sut.PaymentOrders.GetPaymentOrder(id));
            //Assert. NotNull(paymentOrderResponseContainer);
            //Assert.NotNull(paymentOrderResponseContainer.PaymentOrder);

            //var transactionResponse = _sut.PaymentOrders.Reversal(id, new TransactionRequestContainer(new TransactionRequest
            //{
            //    Amount = 100,
            //    VatAmount = 25,
            //    PayeeReference = Guid.NewGuid().ToString(),
            //    Description = "Description for transaction",
            //}));

            //Assert.NotNull(transactionResponse);
            //Assert.Equal("Completed", transactionResponse.State);
        }

        private PaymentOrderRequestContainer CreatePaymentOrderRequestContainer(long amount = 30000, long vatAmount = 7500)
        {
            var paymentOrderRequestContainer = new PaymentOrderRequestContainer
            {
                Paymentorder = new PaymentOrderRequest
                {
                    Amount = amount,
                    VatAmount = vatAmount,
                    Currency = "SEK",
                    Description = "Description",
                    Language = "sv-SE",
                    UserAgent = "useragent",
                    Urls = new Urls
                    {
                        TermsOfServiceUrl = null,
                        CallbackUrl = null,
                        CancelUrl = "https://payex.eu.ngrok.io/payment-canceled?orderGroupId={orderGroupId}",
                        CompleteUrl = "https://payex.eu.ngrok.io/sv/checkout-sv/PayexCheckoutConfirmation/?orderGroupId={orderGroupId}",
                        LogoUrl = null,
                        HostUrls = new List<string> { { "https://payex.eu.ngrok.io" } }
                    },
                    PayeeInfo = new PayeeInfo
                    {
                        PayeeId = "91a4c8e0-72ac-425c-a687-856706f9e9a1",
                        PayeeReference = DateTime.Now.Ticks.ToString(),
                    },
                }
            };
            return paymentOrderRequestContainer;
        }
        
    }
}