namespace SwedbankPay.Sdk.PaymentOrders;

/// <summary>
/// Enum-like mapper for payment order language field.
/// </summary>
public class PaymentOrderLanguage : TypeSafeEnum<PaymentOrderLanguage>
{
    /// <summary>
    /// Swedish language.
    /// </summary>
    public static readonly PaymentOrderLanguage Swedish = new PaymentOrderLanguage(nameof(Swedish), "sv-SE");

    /// <summary>
    /// Norwegian language.
    /// </summary>
    public static readonly PaymentOrderLanguage Norwegian = new PaymentOrderLanguage(nameof(Norwegian), "nb-NO");

    /// <summary>
    /// English language.
    /// </summary>
    public static readonly PaymentOrderLanguage English = new PaymentOrderLanguage(nameof(English), "en-US");

    /// <summary>
    /// Instantiates a <see cref="PaymentOrderLanguage"/> with the provided parameters.
    /// </summary>
    /// <param name="name">Human readable version of the language.</param>
    /// <param name="value">ISO/API version of the language.</param>
    public PaymentOrderLanguage(string name, string value)
        : base(name, value)
    {
    }
}