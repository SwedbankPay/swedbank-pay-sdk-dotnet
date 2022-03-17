﻿using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.Tests.TestBuilders;
using System.Threading.Tasks;
using Xunit;

namespace SwedbankPay.Sdk.Tests.PaymentTests
{
    public class InvoicePaymentTests : ResourceTestsBase
    {
        private readonly PaymentRequestBuilder paymentRequestBuilder = new PaymentRequestBuilder();

        [Fact]
        public async Task CreatePayment()
        {
            var invoicePaymentRequest = this.paymentRequestBuilder.WithInvoiceTestValues(this.payeeId, Operation.FinancingConsumer).BuildInvoiceRequest();
            var invoicePayment = await this.Sut.Payments.InvoicePayments.Create(invoicePaymentRequest, PaymentExpand.All);

            Assert.NotNull(invoicePayment);
            Assert.Equal(invoicePaymentRequest.Payment.Intent, invoicePayment.Payment.Intent);
            Assert.Equal("nb-NO", invoicePayment.Payment.Language.ToString());
            Assert.True(invoicePaymentRequest.Payment.Operation.Equals(Operation.FinancingConsumer));
            Assert.NotEmpty(invoicePaymentRequest.Payment.UserAgent);
            Assert.Equal(UserAgent.Default, invoicePayment.Payment.InitiatingSystemUserAgent);
        }
    }
}
