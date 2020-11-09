namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IInvoicePaymentResponse
    {
        IInvoicePaymentData Payment { get; }
        IInvoicePaymentOperations Operations { get; }
    }
}