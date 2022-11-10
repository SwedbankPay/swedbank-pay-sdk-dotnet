using SwedbankPay.Sdk.PaymentInstruments.Invoice;
using SwedbankPay.Sdk.PaymentInstruments.MobilePay;
using SwedbankPay.Sdk.PaymentInstruments.Trustly;
using SwedbankPay.Sdk.PaymentInstruments.Vipps;

namespace SwedbankPay.Sdk.PaymentInstruments;

internal class ReversalTransactionDto
{
    public ReversalTransactionDto(IReversalTransaction transaction)
    {
        Amount = transaction.Amount.InLowestMonetaryUnit;
        Description = transaction.Description;
        PayeeReference = transaction.PayeeReference;
        VatAmount = transaction.VatAmount.InLowestMonetaryUnit;
        ReceiptReference = transaction.ReceiptReference;
    }

    public ReversalTransactionDto(MobilePayReversalTransaction transaction)
    {
        Amount = transaction.Amount.InLowestMonetaryUnit;
        Description = transaction.Description;
        PayeeReference = transaction.PayeeReference;
        VatAmount = transaction.VatAmount.InLowestMonetaryUnit;
    }

    public ReversalTransactionDto(TrustlyReversalTransaction transaction)
    {
        Amount = transaction.Amount.InLowestMonetaryUnit;
        Description = transaction.Description;
        PayeeReference = transaction.PayeeReference;
        VatAmount = transaction.VatAmount.InLowestMonetaryUnit;
        RecepitReference = transaction.RecepitReference;
        TransactionActivity = transaction.TransactionActivity.Value;
    }

    public ReversalTransactionDto(VippsReversalTransaction transaction)
    {
        Amount = transaction.Amount.InLowestMonetaryUnit;
        Description = transaction.Description;
        PayeeReference = transaction.PayeeReference;
        VatAmount = transaction.VatAmount.InLowestMonetaryUnit;
    }

    public long Amount { get; }

    public string Description { get; }

    public string PayeeReference { get; }

    public long VatAmount { get; }

    public string RecepitReference { get; }

    public string TransactionActivity { get; }

    public string ReceiptReference { get; }
}