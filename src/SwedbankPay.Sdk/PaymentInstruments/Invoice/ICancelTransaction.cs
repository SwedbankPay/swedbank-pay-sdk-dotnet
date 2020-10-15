using SwedbankPay.Sdk.Common;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface ICancelTransaction
    {
        string Description { get; }
        string PayeeReference { get; }
        Operation TransactionActivity { get; }
    }
}