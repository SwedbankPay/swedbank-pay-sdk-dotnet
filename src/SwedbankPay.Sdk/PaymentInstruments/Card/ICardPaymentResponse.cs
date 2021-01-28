namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Object containing details on a credit card payment and
    /// its available operations.
    /// </summary>
    public interface ICardPaymentResponse
    {
        /// <summary>
        /// Details about the card payment.
        /// </summary>
        ICardPayment Payment { get; }

        /// <summary>
        /// Currently available operations on this payment.
        /// </summary>
        ICardPaymentOperations Operations { get; }
    }
}