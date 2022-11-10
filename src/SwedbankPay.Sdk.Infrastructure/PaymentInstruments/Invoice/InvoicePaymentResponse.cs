using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

internal class InvoicePaymentResponse : IInvoicePaymentResponse
{
    public InvoicePaymentResponse(InvoicePaymentResponseDto paymentResponseContainer, HttpClient httpClient)
    {
        var operations = paymentResponseContainer.Operations.Map();
        Operations = new InvoicePaymentOperations(operations, httpClient);
        Payment = new InvoicePaymentDetails(paymentResponseContainer.Payment);
    }

    public IInvoicePaymentOperations Operations { get; }

    public IInvoicePaymentDetails Payment { get; }
}