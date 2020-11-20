namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
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