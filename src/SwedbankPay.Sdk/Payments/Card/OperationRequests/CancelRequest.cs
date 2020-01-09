namespace SwedbankPay.Sdk.Payments.Card.OperationRequests
{
    public class CancelRequest
    {
        public CancelRequest(string payeeReference, string description)
        {
            Transaction = new CancelTransaction(payeeReference, description);
        }

        public CancelTransaction Transaction { get; }

        public class CancelTransaction
        {
            protected internal CancelTransaction(string payeeReference, string description)
            {
                PayeeReference = payeeReference;
                Description = description;
            }

            public string PayeeReference { get; }
            public string Description { get; }
        }
    }
}
