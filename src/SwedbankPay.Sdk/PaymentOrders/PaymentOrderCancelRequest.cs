namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCancelRequest
    {
        public PaymentOrderCancelRequest(string payeeReference, string description)
        {
            Transaction = new PaymentOrderCancelTransaction(payeeReference, description);
        }


        public PaymentOrderCancelTransaction Transaction { get; }
    }
}