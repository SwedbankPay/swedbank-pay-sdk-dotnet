namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CancelRequest
    {
        public CancelRequest(string payeeReference, string description)
        {
            Transaction = new CancelTransaction(payeeReference, description);
        }


        public CancelTransaction Transaction { get; }
    }
}