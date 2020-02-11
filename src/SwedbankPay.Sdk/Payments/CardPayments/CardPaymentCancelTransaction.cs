namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentCancelTransaction
    {
        protected internal CardPaymentCancelTransaction(string payeeReference, string description)
        {
            PayeeReference = payeeReference;
            Description = description;
        }


        public string Description { get; }

        public string PayeeReference { get; }
    }
}