namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCancelRequest
    {
        public PaymentOrderCancelRequest(string payeeReference, string description)
        {
            Transaction = new CancelTransaction(payeeReference, description);
        }


        public CancelTransaction Transaction { get; }
    }
}