namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IInvoicePayment
    {
        IInvoicePaymentOperations Operations { get; }
        PaymentResponseObject PaymentResponse { get; }
    }
}