namespace SwedbankPay.Sdk.PaymentInstruments.Vipps;

/// <summary>
/// API response object for a Vipps payment.
/// </summary>
public interface IVippsPaymentReponse
{
    /// <summary>
    /// The current payment.
    /// </summary>
    public IVippsPayment Payment { get; set; }

    /// <summary>
    /// The currently available operations for this payment.
    /// </summary>
    public IVippsPaymentOperations Operations { get; set; }
}