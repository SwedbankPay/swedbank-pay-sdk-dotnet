namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SwishPaymentReversalTransaction
    {
        public SwishPaymentReversalTransaction(Amount amount, Amount vatAmount, string description, string payeeReference)
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