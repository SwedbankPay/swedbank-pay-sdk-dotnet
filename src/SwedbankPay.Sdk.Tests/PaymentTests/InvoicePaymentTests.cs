using System.Threading.Tasks;
using SwedbankPay.Sdk.Payments;
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
            var invoicePaymentRequest = this.paymentRequestBuilder.WithInvoiceTestValues(this.payeeId, Operation.FinancingConsumer).BuildInvoiceRequest();
            var invoicePayment = await this.Sut.Payments.InvoicePayments.Create(invoicePaymentRequest, PaymentExpand.All);

            Assert.NotNull(invoicePayment);
            Assert.Equal(invoicePaymentRequest.Payment.Intent, invoicePayment.PaymentResponse.Intent);
            Assert.True(invoicePayment.PaymentResponse.Language.Name.Equals("nb-NO"));
            Assert.True(invoicePaymentRequest.Payment.Operation.Equals(Operation.FinancingConsumer));
            Assert.NotEmpty(invoicePaymentRequest.Payment.UserAgent);
        }
    }
}
