using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public partial class CaptureRequest
    {
        public CaptureRequest(Amount amount, Amount vatAmount, List<OrderItem> orderItems, string description, string payeeReference)
        {
            Transaction = new CaptureTransaction(amount, vatAmount, orderItems, description, payeeReference);
        }


        public CaptureTransaction Transaction { get; }
    }
}