namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayReversalRequest
    {
        public MobilePayReversalRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            transaction = new ReversalTransaction(amount, vatAmount, description, payeeReference);
        }

        private ReversalTransaction transaction;

        public Amount Amount => this.transaction.Amount;
        public string Description => this.transaction.Description;
        public string PayeeReference => this.transaction.PayeeReference;
        public Amount VatAmount => this.transaction.VatAmount;

        private class ReversalTransaction
        {
            public ReversalTransaction(Amount amount, Amount vatAmount, string description, string payeeReference)
            {
                Amount = amount;
                VatAmount = vatAmount;
                Description = description;
                PayeeReference = payeeReference;
            }

            public Amount Amount { get; }
            public string Description { get; }
            public string PayeeReference { get; }
            public Amount VatAmount { get; }
        }
    }
}