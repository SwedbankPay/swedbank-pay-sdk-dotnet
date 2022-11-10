namespace SwedbankPay.Sdk;

/// <summary>
/// Indicates the payment method used in the price object.
/// </summary>
public enum PriceType
{
    /// <summary>
    /// Payment method is unknown.
    /// </summary>
    Unknown = default,

    /// <summary>
    /// Payment method is a credit card.
    /// </summary>
    CreditCard,

    /// <summary>
    /// Payment method is a Visa card.
    /// </summary>
    Visa,

    /// <summary>
    /// Payment method is a Mastercard.
    /// </summary>
    MasterCard,

    /// <summary>
    /// Payment method is a Amex card.
    /// </summary>
    Amex,

    /// <summary>
    /// Payment method is a Dankort card.
    /// </summary>
    Dankort,

    /// <summary>
    /// Payment method is a Diners card.
    /// </summary>
    Diners,

    /// <summary>
    /// Payment method is a Finax card.
    /// </summary>
    Finax,

    /// <summary>
    /// Payment method is a Jcb card.
    /// </summary>
    Jcb,

    /// <summary>
    /// Payment method is a Ikano Finans DK card.
    /// </summary>
    IkanoFinansDK,

    /// <summary>
    /// Payment method is a Maestro card.
    /// </summary>
    Maestro,

    /// <summary>
    /// Payment method is a direct debit card.
    /// </summary>
    Directdebit,

    /// <summary>
    /// Payment method is a Swedbank payment method.
    /// </summary>
    SwedbankLV,

    /// <summary>
    /// Payment method is a Swedbank payment method.
    /// </summary>
    SwedbankEE,

    /// <summary>
    /// Payment method is a Swedbank payment method.
    /// </summary>
    SwedbankLT,

    /// <summary>
    /// Payment method is a invoice.
    /// </summary>
    Invoice,

    /// <summary>
    /// Payment method is Mobile Pay Online.
    /// </summary>
    Mobilepay,

    /// <summary>
    /// Payment method is Swish.
    /// </summary>
    Swish,

    /// <summary>
    /// Payment method is Vipps.
    /// </summary>
    Vipps,

    /// <summary>
    /// Payment method is Lindex.
    /// </summary>
    Lindex,

    /// <summary>
    /// Payment method is a Ica card.
    /// </summary>
    Ica,

    /// <summary>
    /// Payment method is handled by Trustly.
    /// </summary>
    Trustly
}