namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay;

/// <summary>
/// Object describing a Mobile Pay payment and its currently available operations.
/// </summary>
public interface IMobilePayPaymentResponse
{
    /// <summary>
    /// The current payment and details about it.
    /// </summary>
    public IMobilePayPayment Payment { get; set; }

    /// <summary>
    /// The currently available operations of the payment.
    /// </summary>
    public IMobilePayPaymentOperations Operations { get; set; }

}