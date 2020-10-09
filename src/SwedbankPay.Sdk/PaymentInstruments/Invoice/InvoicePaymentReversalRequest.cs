namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class InvoicePaymentReversalRequest
    {
        public InvoicePaymentReversalRequest(Operation activity, Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new ReversalTransaction(activity, amount, vatAmount, description, payeeReference);
        }


        public ReversalTransaction Transaction { get; }

        public class ReversalTransaction
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
}