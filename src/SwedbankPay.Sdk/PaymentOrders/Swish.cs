namespace SwedbankPay.Sdk.PaymentOrders;

/// <summary>
/// API detail for setting Swish specific details.
/// </summary>
public class Swish
{
    /// <summary>
    ///  Set enable Swish on ecommerce transactions.
    /// </summary>
    public bool EnableEcomOnly { get; set; }
}