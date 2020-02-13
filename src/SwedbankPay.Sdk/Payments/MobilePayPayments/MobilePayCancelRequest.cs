namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayCancelRequest
    {
        public MobilePayCancelRequest(string payeeReference, string description)
        {
            transaction = new CancelTransaction(payeeReference, description);
        }

        private CancelTransaction transaction;

        public string Description => this.transaction.Description;

        public string PayeeReference => this.transaction.PayeeReference;

        private class CancelTransaction
        {
            protected internal CancelTransaction(string payeeReference, string description)
            {
                PayeeReference = payeeReference;
                Description = description;
            }

            public string Description { get; }
            public string PayeeReference { get; }
        }
    }
}