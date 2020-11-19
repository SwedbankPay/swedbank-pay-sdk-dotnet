namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderUpdateRequest
    {
        public PaymentOrderUpdateRequest(Amount amount, Amount vatAmount)
        {
            PaymentOrder = new PaymentOrderUpdateRequestData(amount, vatAmount);
        }

        /// <summary>
        /// Details about the amount being updated.
        /// </summary>
        public PaymentOrderUpdateRequestData PaymentOrder { get; }
    }
}