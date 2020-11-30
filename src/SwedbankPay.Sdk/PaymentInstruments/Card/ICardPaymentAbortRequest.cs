namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Holds details on aborting a credit card payment.
    /// </summary>
    public interface ICardPaymentAbortRequest
    {
        /// <summary>
        /// Details about the abort.
        /// </summary>
        CardPaymentAbortPayment Payment { get; }
    }
}