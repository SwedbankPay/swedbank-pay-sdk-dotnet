namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentVerificationDto
    {
        public string Id { get; set; }
        public string CardBrand { get; set; }
        public string CardType { get; set; }
        public string PaymentToken { get; set; }
        public string RecurrenceToken { get; set; }
        public string MaskedPan { get; set; }
        public string ExpiryDate { get; set; }
        public string PanToken { get; set; }
        public TransactionDto Transaction { get; set; }
    }
}