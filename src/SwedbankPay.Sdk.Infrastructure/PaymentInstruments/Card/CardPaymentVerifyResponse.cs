namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentVerifyResponse : Identifiable, ICardPaymentVerifyResponse
    {
        public CardPaymentVerifyResponse(CardPaymentVerifyResponseDto dto)
            : base(dto.Id)
        {
            VerificationList = dto.verificationList;
        }

        public ICardPaymentVerifications Verifications { get; }
    }
}
