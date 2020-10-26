using SwedbankPay.Sdk.Common;
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

        private CardPaymentCaptureTransaction Transaction { get; }


        public Amount Amount => this.Transaction.Amount;
        public string Description => this.Transaction.Description;
        public List<OrderItem> OrderItems => this.Transaction.OrderItems;
        public string PayeeReference => this.Transaction.PayeeReference;
        public Amount VatAmount => this.Transaction.VatAmount;


        internal class CardPaymentCaptureTransaction
        {
            protected internal CardPaymentCaptureTransaction(Amount amount,
                                                    Amount vatAmount,
                                                    List<OrderItem> orderItems,
                                                    string description,
                                                    string payeeReference)
            {
                Amount = amount;
                VatAmount = vatAmount;
                OrderItems = orderItems;
                Description = description;
                PayeeReference = payeeReference;
            }


            public Amount Amount { get; }
            public string Description { get; }
            public List<OrderItem> OrderItems { get; }
            public string PayeeReference { get; }
            public Amount VatAmount { get; }
        }
    }
}