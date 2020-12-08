using SwedbankPay.Sdk.PaymentInstruments.Invoice;
using SwedbankPay.Sdk.PaymentInstruments.MobilePay;

namespace SwedbankPay.Sdk.PaymentInstruments
{
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

        public long Amount { get; }

        public string Description { get; }

        public string PayeeReference { get; }

        public long VatAmount { get; }

        public string ReceiptReference { get; }
    }
}