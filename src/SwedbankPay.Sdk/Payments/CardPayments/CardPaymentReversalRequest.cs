using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentReversalRequest
    {
        public CardPaymentReversalRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            transaction = new CardPaymentReversalTransaction(amount, vatAmount, description, payeeReference);
        }


        [JsonProperty]
        private CardPaymentReversalTransaction transaction { get; }

        public Amount Amount => this.transaction.Amount;
        public string Description => this.transaction.Description;
        public string PayeeReference => this.transaction.PayeeReference;
        public Amount VatAmount => this.transaction.VatAmount;

        private class CardPaymentReversalTransaction
        {
            public CardPaymentReversalTransaction(Amount amount, Amount vatAmount, string description, string payeeReference)
            {
                Amount = amount;
                VatAmount = vatAmount;
                Description = description;
                PayeeReference = payeeReference;
            }


            public Amount Amount { get; }
            public string Description { get; }
            public string PayeeReference { get; }
            public Amount VatAmount { get; }
        }
    }
}