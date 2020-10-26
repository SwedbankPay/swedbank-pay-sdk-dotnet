using SwedbankPay.Sdk.Common;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderUpdateRequest
    {
        public PaymentOrderUpdateRequest(Amount amount, Amount vatAmount)
        {
            PaymentOrder = new PaymentOrderUpdateRequestObject(amount, vatAmount);
        }

        public PaymentOrderUpdateRequestObject PaymentOrder { get; }
    }
}