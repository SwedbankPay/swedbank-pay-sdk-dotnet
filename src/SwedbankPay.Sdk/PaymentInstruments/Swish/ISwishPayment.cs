namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    /// <summary>
    /// Describes how a Swish payment returned from the api look like.
    /// </summary>
    public interface ISwishPayment : IIdentifiable, IPaymentInstrument
    {
        /// <summary>
        /// Gives access to available sales transactions on this payment.
        /// </summary>
        ISwishSaleListResponse Sales { get; }
    }
}