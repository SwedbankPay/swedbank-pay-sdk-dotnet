namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class ReversalTransaction : IReversalTransaction
    {
        public ReversalTransaction(Operation activity, Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            TransactionActivity = activity;
            Amount = amount;
            VatAmount = vatAmount;
            Description = description;
            PayeeReference = payeeReference;
        }

        public Operation TransactionActivity { get; }
        public Amount Amount { get; }
        public string Description { get; }
        public string PayeeReference { get; }
        public Amount VatAmount { get; }
    }
}