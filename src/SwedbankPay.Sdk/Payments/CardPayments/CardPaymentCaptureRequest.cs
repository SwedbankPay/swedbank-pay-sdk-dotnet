using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentCaptureRequest
    {
        public CardPaymentCaptureRequest(Amount amount, Amount vatAmount, List<OrderItem> orderItems, string description, string payeeReference)
        {
            transaction = new CardPaymentCaptureTransaction(amount, vatAmount, orderItems, description, payeeReference);
        }

        [JsonProperty]
        private CardPaymentCaptureTransaction transaction { get; }


        public Amount Amount => this.transaction.Amount;
        public string Description => this.transaction.Description;
        public List<OrderItem> OrderItems => this.transaction.OrderItems;
        public string PayeeReference => this.transaction.PayeeReference;
        public Amount VatAmount => this.transaction.VatAmount;


        private class CardPaymentCaptureTransaction
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