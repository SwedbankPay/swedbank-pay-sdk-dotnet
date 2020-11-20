using SwedbankPay.Sdk.PaymentOrders;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentCaptureRequest
    {
        public CardPaymentCaptureRequest(Amount amount, Amount vatAmount, List<OrderItem> orderItems, string description, string payeeReference)
        {
            Transaction = new CardPaymentCaptureTransaction(amount, vatAmount, orderItems, description, payeeReference);
        }

        /// <summary>
        /// Transactional details about the capture.
        /// </summary>
        public CardPaymentCaptureTransaction Transaction { get; }
    }
}