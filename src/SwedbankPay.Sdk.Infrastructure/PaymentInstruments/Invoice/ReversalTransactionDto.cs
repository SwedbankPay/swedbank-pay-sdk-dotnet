namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
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

        public long Amount { get; }

        public string Description { get; }

        public string PayeeReference { get; }

        public long VatAmount { get; }

        public string ReceiptReference { get; }
    }
}