namespace SwedbankPay.Sdk.Transactions
{
    public class CancelTransactionRequest
    {
        public CancelTransactionRequest(string description, string payeeReference)
        {
            Description = description;
            PayeeReference = payeeReference;
        }

        public string Description { get; }
        public string PayeeReference { get; }
    }
}