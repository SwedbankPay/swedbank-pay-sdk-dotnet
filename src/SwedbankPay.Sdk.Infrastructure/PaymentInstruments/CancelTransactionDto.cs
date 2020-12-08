using SwedbankPay.Sdk.PaymentInstruments.Invoice;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class CancelTransactionDto
    {
        public CancelTransactionDto(ICancelTransaction transaction)
        {
            Description = transaction.Description;
            PayeeReference = transaction.PayeeReference;
            TransactionActivity = transaction.TransactionActivity.Value;
        }

        public CancelTransactionDto(MobilePay.CancelTransaction transaction)
        {
            Description = transaction.Description;
            PayeeReference = transaction.PayeeReference;
        }

        public string Description { get; }

        public string PayeeReference { get; }

        public string TransactionActivity { get; }
    }
}