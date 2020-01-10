namespace SwedbankPay.Sdk.Payments.Swish
{
    public class ReversalRequest
    {
        public ReversalRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new ReversalTransaction(amount, vatAmount, description, payeeReference);
        }

        public ReversalTransaction Transaction { get; }


        public class ReversalTransaction
        {
            public ReversalTransaction(Amount amount, Amount vatAmount, string description, string payeeReference)
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
}
