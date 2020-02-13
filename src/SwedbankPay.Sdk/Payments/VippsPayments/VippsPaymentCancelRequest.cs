namespace SwedbankPay.Sdk.Payments.VippsPayments
{
    public class VippsPaymentCancelRequest
    {
        public VippsPaymentCancelRequest(string payeeReference, string description)
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


            public string Description { get; }

            public string PayeeReference { get; }
        }
    }
}