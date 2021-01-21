namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    /// <summary>
    /// Object describing a payment for the Mobile Pay payment instrument.
    /// </summary>
    public interface IMobilePayPayment : IIdentifiable, IPaymentInstrument
    {
        /// <summary>
        /// Currently available list of authorizations.
        /// </summary>
        IMobilePayPaymentAuthorizationList Authorizations { get; }
    }
}