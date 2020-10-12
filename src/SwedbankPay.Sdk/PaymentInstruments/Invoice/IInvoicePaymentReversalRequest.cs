namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IInvoicePaymentReversalRequest
    {
        IReversalTransaction Transaction { get; }
    }
}