using SwedbankPay.Sdk.Common;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
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