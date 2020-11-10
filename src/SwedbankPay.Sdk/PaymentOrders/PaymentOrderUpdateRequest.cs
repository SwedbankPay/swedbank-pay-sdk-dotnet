namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderUpdateRequest
    {
        public PaymentOrderUpdateRequest(Amount amount, Amount vatAmount)
        {
            PaymentOrder = new PaymentOrderUpdateRequestData(amount, vatAmount);
        }

        public PaymentOrderUpdateRequestData PaymentOrder { get; }
    }
}