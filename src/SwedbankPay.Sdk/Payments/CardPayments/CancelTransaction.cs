namespace SwedbankPay.Sdk.Payments.Card
{
    public class CancelTransaction
    {
        protected internal CancelTransaction(string payeeReference, string description)
        {
            PayeeReference = payeeReference;
            Description = description;
        }


        public string Description { get; }

        public string PayeeReference { get; }
    }
}