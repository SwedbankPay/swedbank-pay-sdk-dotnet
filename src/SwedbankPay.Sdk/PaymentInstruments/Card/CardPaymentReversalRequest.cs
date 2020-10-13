namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentReversalRequest
    {
        public Amount Amount { get; }
        public string Description { get; }
        public string PayeeReference { get; }
        public Amount VatAmount { get; }
    }
}