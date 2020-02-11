using System.Collections.Generic;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentCaptureRequest
    {
        public CardPaymentCaptureRequest(Amount amount, Amount vatAmount, List<OrderItem> orderItems, string description, string payeeReference)
        {
            Transaction = new CardPaymentCaptureTransaction(amount, vatAmount, orderItems, description, payeeReference);
        }


        public CardPaymentCaptureTransaction Transaction { get; }
    }
}