namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCancelRequest
    {
        public PaymentOrderCancelRequest(string payeeReference, string description)
        {
            Transaction = new PaymentOrderCancelTransaction(payeeReference, description);
        }

        /// <summary>
        /// Transactional details holding the payee reference, and a description of the cancellation.
        /// </summary>
        public PaymentOrderCancelTransaction Transaction { get; }
    }
}