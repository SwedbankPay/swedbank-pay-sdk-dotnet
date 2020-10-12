namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface ICancelTransaction
    {
        string Description { get; }
        string PayeeReference { get; }
        Operation TransactionActivity { get; }
    }
}