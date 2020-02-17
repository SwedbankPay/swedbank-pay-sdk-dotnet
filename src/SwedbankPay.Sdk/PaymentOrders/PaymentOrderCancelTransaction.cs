namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCancelTransaction
    {
        protected internal PaymentOrderCancelTransaction(string payeeReference, string description)
        {
            PayeeReference = payeeReference;
            Description = description;
        }


        public string Description { get; }

        public string PayeeReference { get; }
    }
}