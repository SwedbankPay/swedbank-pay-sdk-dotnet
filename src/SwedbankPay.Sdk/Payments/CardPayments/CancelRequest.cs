namespace SwedbankPay.Sdk.Payments.CardPayments
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