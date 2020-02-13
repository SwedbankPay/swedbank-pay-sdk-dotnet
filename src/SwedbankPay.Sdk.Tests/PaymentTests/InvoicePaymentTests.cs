using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SwedbankPay.Sdk.Payments;
using SwedbankPay.Sdk.Payments.InvoicePayments;
using SwedbankPay.Sdk.Tests.TestBuilders;
using Xunit;

namespace SwedbankPay.Sdk.Tests.PaymentTests
{
    public class InvoicePaymentTests : ResourceTestsBase
    {
        private readonly PaymentRequestBuilder paymentRequestBuilder = new PaymentRequestBuilder();

        [Fact]
        public async Task CreatePayment()
        {
            var invoicePaymentRequest = this.paymentRequestBuilder.WithInvoiceTestValues(Operation.FinancingConsumer).BuildInvoiceRequest();
            var invoicePayment = await this.Sut.Payment.InvoicePayments.Create(paymentRequest, PaymentExpand.All);

            Assert.NotNull(invoicePayment);
            Assert.Equal(invoicePaymentRequest.Payment.MetaData["key1"], invoicePayment.PaymentResponse.MetaData["key1"]);
            Assert.True(invoicePaymentRequest.Payment.Language.CultureTypes.Equals("nb-NO"));
            Assert.True(invoicePaymentRequest.Payment.Operation.Equals(Operation.FinancingConsumer));
            Assert.NotNull(invoicePaymentRequest.Payment.UserAgent);

        }
    }
}
