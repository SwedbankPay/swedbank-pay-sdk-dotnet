namespace SwedbankPay.Sdk.PaymentOrders
{
    public class UpdateRequest
    {
        public UpdateRequest(Amount amount, Amount vatAmount)
        {
            PaymentOrder = new PaymentOrderUpdateRequestObject(amount, vatAmount);
        }
        
        public PaymentOrderUpdateRequestObject PaymentOrder { get; }
    }
}