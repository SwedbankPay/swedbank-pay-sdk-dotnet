namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class CancelTransactionDto
    {
        public CancelTransactionDto(ICancelTransaction transaction)
        {
            Description = transaction.Description;
            PayeeReference = transaction.PayeeReference;
            TransactionActivity = transaction.TransactionActivity.Value;
        }

        public string Description { get; }

        public string PayeeReference { get; }

        public string TransactionActivity { get; }
    }
}