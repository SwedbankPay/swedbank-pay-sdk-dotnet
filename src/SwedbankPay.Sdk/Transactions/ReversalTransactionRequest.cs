namespace SwedbankPay.Sdk.Transactions
{
    public class ReversalTransactionRequest
    {
        public ReversalTransactionRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Amount = amount;
            VatAmount = vatAmount;
            Description = description;
            PayeeReference = payeeReference;
        }


        public Amount Amount { get; }
        public Amount VatAmount { get; }
        public string Description { get; }
        public string PayeeReference { get; }
    }
}
