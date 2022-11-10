namespace SwedbankPay.Sdk.PaymentInstruments.Trustly;

/// <summary>
/// Object holding a Trustly payment and its available operations.
/// </summary>
public interface ITrustlyPaymentResponse
{
    /// <summary>
    /// Details about the current Trustly payment.
    /// </summary>
    public ITrustlyPayment Payment { get; set; }

    /// <summary>
    /// Currently available operations on the current Trustly payment.
    /// </summary>
    public ITrustlyPaymentOperations Operations { get; set; }
}