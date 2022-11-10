namespace SwedbankPay.Sdk.PaymentInstruments.Swish;

/// <summary>
/// Object for setting E-Commerce options for a Swish payment.
/// </summary>
public class SwishRequestData
{
    /// <summary>
    /// Set to only enable Swish on browser based transactions.
    /// Otherwise to also enable Swish transactions via in-app payments.
    /// </summary>
    public bool EnableEcomOnly { get; set; }
}