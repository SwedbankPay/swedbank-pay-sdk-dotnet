using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentResponse : IInvoicePaymentResponse
    {
        public InvoicePaymentResponse(InvoicePaymentResponseDto paymentResponseContainer, HttpClient httpClient)
        {
            var operations = paymentResponseContainer.Operations.Map();
            Operations = new InvoicePaymentOperations(operations, httpClient);
            Payment = new InvoicePaymentData(paymentResponseContainer.Payment);
        }

        public IInvoicePaymentOperations Operations { get; }

        public IInvoicePaymentData Payment { get; }
    }
}