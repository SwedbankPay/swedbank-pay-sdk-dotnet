namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderUpdateRequest
    {
        public PaymentOrderUpdateRequest(Amount amount, Amount vatAmount)
        {
            PaymentOrder = new PaymentOrderUpdateRequestDetails(amount, vatAmount);
        }

        /// <summary>
        /// Details about the amount being updated.
        /// </summary>
        public PaymentOrderUpdateRequestDetails PaymentOrder { get; }
    }
}