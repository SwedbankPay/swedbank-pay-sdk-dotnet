using SwedbankPay.Sdk.PaymentInstruments;
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
            var invoicePaymentRequest = paymentRequestBuilder.WithInvoiceTestValues(payeeId, Operation.FinancingConsumer).BuildInvoiceRequest();
            var invoicePayment = await Sut.Payments.InvoicePayments.Create(invoicePaymentRequest, PaymentExpand.All);

            Assert.NotNull(invoicePayment);
            Assert.Equal(invoicePaymentRequest.Payment.Intent, invoicePayment.Payment.Intent);
            Assert.Equal("nb-NO", invoicePayment.Payment.Language.ToString());
            Assert.True(invoicePaymentRequest.Payment.Operation.Equals(Operation.FinancingConsumer));
            Assert.NotEmpty(invoicePaymentRequest.Payment.UserAgent);
        }
    }
}
