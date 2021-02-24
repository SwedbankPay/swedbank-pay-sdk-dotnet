namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Object describing a verified card payment.
    /// </summary>
    public interface ICardPaymentVerification : IIdentifiable
    {
        /// <summary>
        /// Brand used for the payment.
        /// </summary>
        string CardBrand { get; }

        /// <summary>
        /// The type of card used.
        /// </summary>
        string CardType { get; }

        /// <summary>
        /// The secure payment token for this verified payment.
        /// </summary>
        string PaymentToken { get; }

        /// <summary>
        /// If recurrence is set the token for it can be found here.
        /// </summary>
        string RecurrenceToken { get; }

        /// <summary>
        /// The masked Primary Account Number
        /// </summary>
        string MaskedPan { get; }

        /// <summary>
        /// The expiry date of the used card,
        /// format: MM/YY
        /// </summary>
        string ExpiryDate { get; }

        /// <summary>
        /// The token representing the specific PAN of the card.
        /// </summary>
        string PanToken { get; }

        /// <summary>
        /// Transactional details for this verified transaction.
        /// </summary>
        IVerifyTransaction Transaction { get; }

        /// <summary>
        /// True if this transaction is operational.
        /// </summary>
        bool IsOperational { get; }

        /// <summary>
        /// Indicates any problems with the transaction.
        /// </summary>
        IProblem Problem { get; }
    }
}