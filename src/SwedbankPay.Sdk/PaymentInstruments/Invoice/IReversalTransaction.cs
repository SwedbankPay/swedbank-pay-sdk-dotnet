namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IReversalTransaction
    {
        Amount Amount { get; }
        string Description { get; }
        string PayeeReference { get; }
        Operation TransactionActivity { get; }
        Amount VatAmount { get; }
    }
}