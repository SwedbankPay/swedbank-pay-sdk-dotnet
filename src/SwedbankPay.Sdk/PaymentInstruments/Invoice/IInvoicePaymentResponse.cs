namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IInvoicePaymentResponse
    {
        IInvoicePayment Payment { get; }
        IInvoicePaymentOperations Operations { get; }
    }
}