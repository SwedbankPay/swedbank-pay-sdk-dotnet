using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCaptureRequest
    {
        public PaymentOrderCaptureRequest(Amount amount, Amount vatAmount, List<OrderItem> orderItems, string description, string payeeReference)
        {
            Transaction = new CaptureTransaction(amount, vatAmount, orderItems, description, payeeReference);
        }


        public CaptureTransaction Transaction { get; }
    }
}