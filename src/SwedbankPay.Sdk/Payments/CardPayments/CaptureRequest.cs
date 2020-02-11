using System.Collections.Generic;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.Card
{
    public class CaptureRequest
    {
        public CaptureRequest(Amount amount, Amount vatAmount, List<OrderItem> orderItems, string description, string payeeReference)
        {
            Transaction = new CaptureTransaction(amount, vatAmount, orderItems, description, payeeReference);
        }


        public CaptureTransaction Transaction { get; }
    }
}