namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IInvoicePaymentCancelRequest
    {
        ICancelTransaction Transaction { get; }
    }
}