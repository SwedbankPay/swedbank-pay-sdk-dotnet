namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class ReversalTransaction : IReversalTransaction
    {
        public ReversalTransaction(Amount amount, Amount vatAmount, string description, string payeeReference, string receiptReference)
        {
            Amount = amount;
            VatAmount = vatAmount;
            Description = description;
            PayeeReference = payeeReference;
            ReceiptReference = receiptReference;
        }

        public Amount Amount { get; }
        public string Description { get; }
        public string PayeeReference { get; }
        public Amount VatAmount { get; }

        public string ReceiptReference { get; }
    }
}