namespace SwedbankPay.Sdk
{
    /// <summary>
    ///     Payment Instrument
    /// </summary>

    public enum PaymentInstrument
    {
        /// <summary>
        /// Instrument is unknown, default value.
        /// </summary>
        Unknown = default,

        /// <summary>
        /// Invoice payment instrument.
        /// </summary>
        Invoice,

        /// <summary>
        /// MobilePay payment instrument.
        /// </summary>
        MobilePay,

        /// <summary>
        /// Credit card payment instrument.
        /// </summary>
        CreditCard,

        /// <summary>
        /// Swish payment instrument.
        /// </summary>
        Swish,

        /// <summary>
        /// Vipps payment instrument.
        /// </summary>
        Vipps,

        /// <summary>
        /// Direct debit payment instrument.
        /// </summary>
        DirectDebit,

        /// <summary>
        /// Trustly payment instrument.
        /// </summary>
        Trustly
    }
}
