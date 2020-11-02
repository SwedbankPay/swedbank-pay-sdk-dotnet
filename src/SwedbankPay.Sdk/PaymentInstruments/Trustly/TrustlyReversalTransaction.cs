namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public class TrustlyReversalTransaction
    {
        public TrustlyReversalTransaction(Operation activity, Amount amount, Amount vatAmount, string payeeReference, string receiptReference, string description)
        {
            TransactionActivity = activity;
            Amount = amount;
            VatAmount = vatAmount;
            Description = description;
            PayeeReference = payeeReference;
            RecepitReference = receiptReference;
        }

        public Operation TransactionActivity { get; }
        public Amount Amount { get; }
        public string Description { get; }
        public string PayeeReference { get; }
        public string RecepitReference { get; }
        public Amount VatAmount { get; }
    }
}
