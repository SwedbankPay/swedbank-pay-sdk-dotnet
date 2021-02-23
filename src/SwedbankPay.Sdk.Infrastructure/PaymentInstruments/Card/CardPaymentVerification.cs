namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentVerification : Identifiable, ICardPaymentVerification
    {
        public CardPaymentVerification(CardPaymentVerificationDto dto)
            : base(dto.Id)
        {
            PaymentToken = dto.PaymentToken;
            RecurrenceToken = dto.RecurrenceToken;
            MaskedPan = dto.MaskedPan;
            ExpiryDate = dto.ExpiryDate;
            PanToken = dto.PanToken;
            CardBrand = dto.CardBrand;
            CardType = dto.CardType;
            Transaction = dto.Transaction.Map();
        }

        public string CardBrand { get; }
        public string CardType { get; }
        public string PaymentToken { get; }
        public string RecurrenceToken { get; }
        public string MaskedPan { get; }
        public string ExpiryDate { get; }
        public string PanToken { get; }
        public ITransaction Transaction { get; }
    }
}