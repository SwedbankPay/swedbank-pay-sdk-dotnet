namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IInvoicePaymentResponse
    {
        IInvoicePayment Payment { get; }
        IInvoicePaymentOperations Operations { get; }
    }
}