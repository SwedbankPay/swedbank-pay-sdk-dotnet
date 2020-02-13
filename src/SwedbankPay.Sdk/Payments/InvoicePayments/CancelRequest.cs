namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class CancelRequest
    {
        public CancelRequest(Operation transactionActivity, string payeeReference, string description)
        {
            Transaction = new CancelTransaction(transactionActivity, payeeReference, description);
        }


        public CancelTransaction Transaction { get; }

        public class CancelTransaction
        {
            protected internal CancelTransaction(Operation transactionActivity, string payeeReference, string description)
            {
                TransactionActivity = transactionActivity;
                PayeeReference = payeeReference;
                Description = description;
            }

            public Operation TransactionActivity { get; }
            public string Description { get; }

            public string PayeeReference { get; }
        }
    }
}