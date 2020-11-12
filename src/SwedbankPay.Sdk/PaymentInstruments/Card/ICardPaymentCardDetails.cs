namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentCardDetails
    {
        /// <summary>
        /// Expiry month of the card, printed on the face of the card
        /// </summary>
        int CardExpiryMonth { get; }

        /// <summary>
        /// Expiry year of the card, printed on the face of the card
        /// </summary>
        int CardExpiryYear { get; }

        /// <summary>
        /// Name of the card holder, usually printed on the face of the card
        /// </summary>
        string CardHolderName { get; }

        /// <summary>
        /// Primary Account Number (PAN) of the card, printed on the face of the card
        /// This field is masked for security
        /// </summary>
        string CardNumber { get; }

        /// <summary>
        /// Card verification code (CVC/CVV/CVC2), usually printed on the back of the card
        /// </summary>
        string CardVerificationCode { get; }
    }
}