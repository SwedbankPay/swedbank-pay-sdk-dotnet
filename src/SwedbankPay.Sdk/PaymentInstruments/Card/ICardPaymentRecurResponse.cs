namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentRecurResponse
    {
        /// <summary>
        /// The current recur payment.
        /// </summary>
        ICardPaymentRecurResponseDetails Payment { get; }

        /// <summary>
        /// The available operations on this payment.
        /// </summary>
        ICardPaymentOperations Operations { get; }
    }
}