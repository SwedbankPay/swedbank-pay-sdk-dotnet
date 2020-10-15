using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentResponse : IInvoicePaymentResponse
    {
        public InvoicePaymentResponse(InvoicePaymentResponseDto paymentResponseContainer, HttpClient httpClient)
        {
            Operations = new InvoicePaymentOperations(paymentResponseContainer.Operations.Map(), httpClient);
            Payment = new InvoicePayment(paymentResponseContainer.Payment);
        }

        public IInvoicePaymentOperations Operations { get; }

        public IInvoicePayment Payment { get; }
    }
}