namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentReversalRequest
    {
        public Amount Amount { get; }
        public string Description { get; }
        public string PayeeReference { get; }
        public Amount VatAmount { get; }
    }
}